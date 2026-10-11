using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CookComputing.XmlRpc;
using MolineSoftware.DrupalXmlRpc;

namespace trade {
    public partial class frm_main : Form {
        #region | Private Properties |
        private DrupalService service;
        private bool connected = false;
        private bool cancelRequested = false;
        #endregion

        #region | Constructor |
        public frm_main() {
            InitializeComponent();

            // Close the Connection, if open.
            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
        }
        #endregion

        #region | Control Events |

        void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            try
            {
                if (connected)
                    service.Logout(false);
            }
            catch { }
        }

        private void btn_connect_click(object sender, EventArgs e) {
            try {
                this.Cursor = Cursors.WaitCursor;

                if (!connected)
                    Connect();
                else
                    Disconnect();
            }
            catch (Exception ex) {
                ErrorHandler(ex);
            }
            finally {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            cancelRequested = true;
            btn_cancel.Enabled = false;
            Log("Запрошена отмена...");
        }

        private void buttonNodeGet_Click(object sender, EventArgs e) {
            try {
                if (!EnsureConnected())
                    return;

                int nid = 406;
                CustomNode loadedNode = service.GetNode<CustomNode>(nid, DrupalNode.AllFields, false);
                this.textbox_node_body.Text = loadedNode.Body;
                this.textbox_title.Text = loadedNode.Title;
            }
            catch (Exception ex) {
                ErrorHandler(ex);
            }
        }

        private void buttonAddNew_Click(object sender, EventArgs e) {
            RunImport("Excel.New", "new.xlsx",
                delegate(ExcelFile book) {
                    ImportRows(book, (int)updown_new_count.Value, ImportNewRow);
                });
        }

        private void btn_add_special_click(object sender, EventArgs e) {
            RunImport("Excel.Special", "special.xlsx",
                delegate(ExcelFile book) {
                    ImportRows(book, (int)updown_special_count.Value, ImportSpecRow);
                });
        }

        private void btn_add_parts_click(object sender, EventArgs e) {
            RunImport("Excel.Parts", "parts.xlsx", ImportParts);
        }

        #endregion

        #region | Import Pipeline |

        /// <summary>
        /// Общий каркас импорта: проверка подключения, открытие книги Excel,
        /// гарантированное закрытие (using -> ExcelFile.Dispose), лог и сброс состояния UI.
        /// </summary>
        private void RunImport(string configKey, string defaultFileName, Action<ExcelFile> import)
        {
            if (!EnsureConnected())
                return;

            try
            {
                SetBusy(true);

                string path = AppConfig.GetPath(configKey, defaultFileName);
                Log("Открываю файл: " + path);

                using (ExcelFile book = ExcelFile.Open(path))
                {
                    import(book);
                }

                if (!cancelRequested)
                    Log("READY!");
            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
            }
            finally
            {
                SetBusy(false);
            }
        }

        /// <summary>
        /// Общий цикл по строкам листа: прогресс + возможность отмены.
        /// </summary>
        private void ImportRows(ExcelFile book, int rowCount, Action<Excel.Worksheet, int> importRow)
        {
            Excel.Worksheet sheet = book.GetSheet(1);
            InitProgress(rowCount);

            for (int i = 1; i <= rowCount; i++)
            {
                Application.DoEvents();
                if (cancelRequested)
                {
                    Log("Импорт отменён, сохранены строки 1.." + (i - 1) + ".");
                    return;
                }

                importRow(sheet, i);
                SetProgress(i, rowCount);
            }
        }

        /// <summary>
        /// Импорт строки вкладки «Добавление новинок» (новинки КАМАЗ).
        /// </summary>
        private void ImportNewRow(Excel.Worksheet sheet, int row)
        {
            CustomNode node = new CustomNode();
            node.Type = "autotech";

            string model = ExcelFile.GetCell(sheet, row, 2);

            node._Path = ExcelFile.GetCell(sheet, row, 1);
            node._IMGDir.AddValue(node._Path);
            node._Model.AddValue(model);

            string gCat = ExcelFile.GetCell(sheet, row, 11);
            node._gCategory.AddValue(gCat);

            switch (gCat)
            {
                case "1":
                    node.Title = "КАМАЗ бортовой " + model;
                    break;
                case "2":
                    node.Title = "КАМАЗ бортовой " + model + " с КМУ";
                    break;
                case "3":
                    node.Title = "Седельный тягач КАМАЗ " + model;
                    break;
                case "4":
                    node.Title = "КАМАЗ самосвал " + model;
                    break;
                case "5":
                    node.Title = "Шасси КАМАЗ " + model;
                    break;
                default:
                    // Раньше заголовок в этом случае брался от предыдущей строки (или оставался пустым)
                    node.Title = model;
                    Log(string.Format("Строка {0}: неизвестная категория «{1}», заголовок взят из модели.", row, gCat));
                    break;
            }

            node._KF.AddValue(ExcelFile.GetCell(sheet, row, 3));
            node._Oshinov.AddValue(ExcelFile.GetCell(sheet, row, 4));
            node._Gruzpod.AddValue(ExcelFile.GetCell(sheet, row, 5));
            node._Horse.AddValue(ExcelFile.GetCell(sheet, row, 6));
            node._Chassis.AddValue(ExcelFile.GetCell(sheet, row, 7));
            node._KPP.AddValue(ExcelFile.GetCell(sheet, row, 8));
            node._VMontazhn.AddValue(ExcelFile.GetCell(sheet, row, 9));
            node._Spaln.AddValue(ExcelFile.GetCell(sheet, row, 10));
            node._Fuel.AddValue(ExcelFile.GetCell(sheet, row, 12));
            node._TSUObozn.AddValue(ExcelFile.GetCell(sheet, row, 13));
            node._Osobennosti.AddValue(ExcelFile.GetCell(sheet, row, 14));
            node._Engine.AddValue(ExcelFile.GetCell(sheet, row, 15));

            FillNodeMeta(node);

            string message = service.SaveNode<DrupalNode>(node, false);
            Log(string.Format("Saved Node. NodeID: {0} {1}", message, node._Path));
        }

        /// <summary>
        /// Импорт строки вкладки «Спецтехнику».
        /// </summary>
        private void ImportSpecRow(Excel.Worksheet sheet, int row)
        {
            TradeNode node = new TradeNode();
            node.Type = "autotech";
            node._gCategory.AddValue(this.updown_category.Value.ToString());

            node._Path = ExcelFile.GetCell(sheet, row, 5);
            node._IMGDir.AddValue(node._Path);

            node.Title = ExcelFile.GetCell(sheet, row, 6) + " " +
                         ExcelFile.GetCell(sheet, row, 1) + " на шасси КАМАЗ";
            node._Model.AddValue(ExcelFile.GetCell(sheet, row, 1));

            string tsu = ExcelFile.GetCell(sheet, row, 2);
            if (tsu.Length > 0)
                node._TSUObozn.AddValue(tsu);

            node._Osobennosti.AddValue(ExcelFile.GetCell(sheet, row, 4));
            node._Chassis.AddValue(ExcelFile.GetCell(sheet, row, 3));

            FillNodeMeta(node);

            string message = service.SaveNode<DrupalNode>(node, false);
            Log(string.Format("Saved aNode. aNodeID: {0} {1}", message, node._Path));
        }

        /// <summary>
        /// Импорт вкладки «Запчасти»: все листы книги собираются в HTML со вкладками.
        /// </summary>
        private void ImportParts(ExcelFile book)
        {
            EvenNode node = new EvenNode();
            List<string> stringList = new List<string>(new[] { " " });
            stringList.Add("<script src=\"http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js\"></script>");
            stringList.Add("<script src=\"/multimedia/stuff/rootab.js\"></script>");
            stringList.Add("<link type=\"text/css\" rel=\"stylesheet\" media=\"all\" href=\"/multimedia/stuff/rootab.css\" />");
            stringList.Add("<div id=\"wrapper\"><ul class=\"tabs1\">");

            int sheetsCount = book.SheetCount;
            InitProgress(sheetsCount);

            node.Title = ExcelFile.GetCell(book.GetSheet(1), 2, 3);

            for (int i = 1; i <= sheetsCount; i++)
            {
                stringList.Add("<li><a href=\"#\" class=\"defaulttab\" rel=\"tabs" + i + "\">" +
                               book.GetSheetName(i) + "</a></li>");
            }
            stringList.Add("</ul>");

            const int firstRow = 5;

            for (int i = 1; i <= sheetsCount; i++)
            {
                Application.DoEvents();
                if (cancelRequested)
                {
                    Log("Импорт отменён, нода не сохранена.");
                    return;
                }

                Excel.Worksheet sheet = book.GetSheet(i);
                int excelRow = firstRow;

                stringList.Add("<div class=\"tab-content\" id=\"tabs" + i + "\"><table class=\"aa2\" border=\"1\">");
                stringList.Add("<tr><td width=\"5%\">№ п/п</td><td width=\"60%\">Наименование</td><td width=\"15%\">Код</td><td width=\"5%\">Количество</td><td width=\"15%\">Цена</td>");

                while (ExcelFile.GetCellValue(sheet, excelRow, 1) != null)
                {
                    Application.DoEvents();
                    if (cancelRequested)
                    {
                        Log("Импорт отменён, нода не сохранена.");
                        return;
                    }

                    stringList.Add("<tr><td>" + ExcelFile.GetCell(sheet, excelRow, 1) + "</td>");
                    stringList.Add("<td>" + ExcelFile.GetCell(sheet, excelRow, 2) + "</td>");
                    stringList.Add("<td>" + ExcelFile.GetCell(sheet, excelRow, 3) + "</td>");
                    stringList.Add("<td>" + ExcelFile.GetCell(sheet, excelRow, 4) + "</td>");
                    stringList.Add("<td>" + ExcelFile.GetCell(sheet, excelRow, 6) + "</td></tr>");

                    excelRow++;
                }

                stringList.Add("</table></div>");
                SetProgress(i, sheetsCount);
            }
            stringList.Add("</div>"); /* #wrapper */

            node.Type = "unsearch";
            node.Format = "3"; /* PHP */
            node.Body = string.Join("\r\n", stringList.ToArray());

            FillNodeMeta(node);

            string message = service.SaveNode<DrupalNode>(node, false);
            Log(string.Format("Saved EvenNode. EvenNodeID: {0}", message));
        }

        /// <summary>
        /// Даты и автор ноды — общий код для всех типов нод.
        /// </summary>
        private void FillNodeMeta(DrupalNode node)
        {
            node.ChangeDate = DrupalService.GetUnixTimestamp().ToString();
            node.RevisionDate = DrupalService.GetUnixTimestamp().ToString();
            node.UserID = service.LoginInfo.User.UserID.ToString();
            node.UserName = service.LoginInfo.User.UserName;
        }

        #endregion

        #region | Connection |

        private void Connect()
        {
            string serviceKey = AppConfig.Get("Drupal.ServiceKey");
            string serviceDomain = AppConfig.Get("Drupal.ServiceDomain");
            string serviceUrl = AppConfig.Get("Drupal.ServiceUrl");
            string userName = AppConfig.Get("Drupal.UserName");

            if (string.IsNullOrEmpty(serviceKey) || string.IsNullOrEmpty(serviceDomain) ||
                string.IsNullOrEmpty(serviceUrl) || string.IsNullOrEmpty(userName))
            {
                MessageBox.Show(
                    "Не заданы настройки подключения.\r\n\r\n" +
                    "Укажите Drupal.ServiceKey, Drupal.ServiceDomain, Drupal.ServiceUrl и Drupal.UserName\r\n" +
                    "в файле App.config (раздел appSettings).",
                    "Нет настроек", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            service = new DrupalService(serviceKey, serviceDomain, serviceUrl);
            service.Connect(false);

            // Пароль в коде не хранится: берём из App.config или спрашиваем при подключении
            string password = AppConfig.Get("Drupal.Password");
            if (string.IsNullOrEmpty(password))
                password = PasswordDialog.AskPassword(this, userName);

            if (password == null)
            {
                // Ввод отменён — выходим без входа
                service = null;
                return;
            }

            service.Login(userName, password, false);

            btn_connect.Text = "Disconnect";
            text_user.Text = "Logged in As: " + service.LoginInfo.User.UserName;
            text_user.BackColor = Color.Green;
            connected = true;
        }

        private void Disconnect()
        {
            service.Logout(false);
            btn_connect.Text = "Connect";
            text_user.Text = "Disconnected";
            text_user.BackColor = Color.Red;
            connected = false;
        }

        /// <summary>
        /// Проверяет, что есть подключение к серверу; иначе просит подключиться.
        /// </summary>
        private bool EnsureConnected()
        {
            if (connected && service != null)
                return true;

            MessageBox.Show(
                "Сначала выполните подключение к серверу (кнопка Connect).",
                "Нет подключения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        #endregion

        #region | UI Helpers |

        /// <summary>
        /// Блокирует интерфейс на время импорта; включает кнопку «Отмена».
        /// </summary>
        private void SetBusy(bool value)
        {
            cancelRequested = false;

            btn_connect.Enabled = !value;
            btn_node_get.Enabled = !value;
            btn_add_new.Enabled = !value;
            btn_add_special.Enabled = !value;
            btn_parts.Enabled = !value;
            btn_cancel.Enabled = value;

            progress_bar.Value = 0;
        }

        private void InitProgress(int maximum)
        {
            progress_bar.Minimum = 0;
            progress_bar.Maximum = Math.Max(1, maximum);
            progress_bar.Value = 0;
        }

        private void SetProgress(int current, int maximum)
        {
            progress_bar.Maximum = Math.Max(1, maximum);
            progress_bar.Value = Math.Min(Math.Max(0, current), progress_bar.Maximum);
        }

        private void Log(string message)
        {
            textbox_log.AppendText(message + "\r\n");
        }

        private void ErrorHandler(Exception ex)
        {
            Exception detail = ex;
            while (detail.InnerException != null)
                detail = detail.InnerException;

            string text = ex.Message;
            if (detail != ex)
                text += "\r\n\r\nВнутренняя ошибка: " + detail.Message;

            Log("ОШИБКА: " + text.Replace("\r\n", " "));
            MessageBox.Show(text, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        public class EvenNode : DrupalNode {
            public EvenNode() : base() { base.Type = "custom_node"; }

            [XmlRpcMember(Member = "path")]
            public string _Path { get; set; }
        }
    }
}
