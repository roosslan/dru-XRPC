using System.Drawing;
using System.Windows.Forms;

namespace trade {
    /// <summary>
    /// Запрос пароля подключения, если Drupal.Password не задан в App.config.
    /// Пароль не сохраняется — живёт только в памяти текущего сеанса.
    /// </summary>
    internal static class PasswordDialog {
        /// <summary>
        /// Показывает диалог ввода пароля.
        /// </summary>
        /// <returns>Введённый пароль или null, если пользователь отменил ввод.</returns>
        public static string AskPassword(IWin32Window owner, string userName) {
            using (Form form = new Form()) {
                Label label = new Label();
                TextBox textBox = new TextBox();
                Button okButton = new Button();
                Button cancelButton = new Button();

                label.AutoSize = true;
                label.Location = new Point(12, 15);
                label.Text = "Пароль для пользователя «" + userName + "»:";

                textBox.Location = new Point(12, 35);
                textBox.Size = new Size(280, 22);
                textBox.UseSystemPasswordChar = true;

                okButton.Text = "OK";
                okButton.DialogResult = DialogResult.OK;
                okButton.Location = new Point(136, 68);
                okButton.Size = new Size(75, 25);

                cancelButton.Text = "Отмена";
                cancelButton.DialogResult = DialogResult.Cancel;
                cancelButton.Location = new Point(217, 68);
                cancelButton.Size = new Size(75, 25);

                form.Text = "Вход на сервер";
                form.ClientSize = new Size(304, 105);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowInTaskbar = false;
                form.AcceptButton = okButton;
                form.CancelButton = cancelButton;
                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(okButton);
                form.Controls.Add(cancelButton);

                if (form.ShowDialog(owner) == DialogResult.OK)
                    return textBox.Text;

                return null;
            }
        }
    }
}
