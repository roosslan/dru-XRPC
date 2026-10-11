using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace trade {
    /// <summary>
    /// Открытая книга Excel (только чтение).
    /// Всё взаимодействие с Excel заворачивается в using: Dispose закрывает книгу,
    /// гасит процесс Excel и освобождает COM-объекты — даже при исключении в обработчике,
    /// поэтому зомби-EXCEL.EXE не остаётся.
    /// </summary>
    internal sealed class ExcelFile : IDisposable {
        private readonly List<Excel.Worksheet> _openedSheets = new List<Excel.Worksheet>();
        private Excel.Application _application;
        private Excel.Workbook _workbook;
        private Excel.Sheets _sheets;
        private bool _disposed;

        private ExcelFile() {
        }

        #region | Properties |
        /// <summary>
        /// Количество листов в книге.
        /// </summary>
        public int SheetCount
        {
            get { return _sheets.Count; }
        }
        #endregion

        #region | Public Methods |
        /// <summary>
        /// Открывает книгу в Excel только для чтения.
        /// </summary>
        /// <param name="fileName">Полный путь к файлу .xlsx</param>
        public static ExcelFile Open(string fileName) {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Не задан путь к Excel-файлу.", "fileName");

            if (!File.Exists(fileName))
                throw new FileNotFoundException(
                    "Excel-файл не найден:\r\n" + fileName +
                    "\r\n\r\nПроверьте путь в App.config (раздел appSettings).", fileName);

            ExcelFile file = new ExcelFile();
            try {
                file._application = new Excel.ApplicationClass();
                file._application.Visible = false;
                file._application.DisplayAlerts = false;
                file._workbook = file._application.Workbooks.Open(fileName,
                    0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, null, null);
                file._sheets = file._workbook.Worksheets;
                return file;
            }
            catch {
                file.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Лист по индексу (с 1). Листы кэшируются, чтобы не плодить COM-обёртки.
        /// </summary>
        public Excel.Worksheet GetSheet(int index) {
            while (_openedSheets.Count < index) {
                _openedSheets.Add((Excel.Worksheet)_sheets.get_Item(_openedSheets.Count + 1));
            }
            return _openedSheets[index - 1];
        }

        /// <summary>
        /// Имя листа по индексу (с 1).
        /// </summary>
        public string GetSheetName(int index) {
            return GetSheet(index).Name;
        }

        /// <summary>
        /// Сырое значение ячейки: null — если ячейка пуста (как в исходном коде).
        /// </summary>
        public static object GetCellValue(Excel.Worksheet sheet, int row, int column) {
            Excel.Range range = sheet.Cells[row, column] as Excel.Range;
            return range == null ? null : range.Value2;
        }

        /// <summary>
        /// Значение ячейки в виде строки; пустая ячейка — пустая строка (не бросает исключений).
        /// </summary>
        public static string GetCell(Excel.Worksheet sheet, int row, int column) {
            object value = GetCellValue(sheet, row, column);
            return value == null ? string.Empty : value.ToString().Trim();
        }

        /// <summary>
        /// Закрывает книгу, гасит Excel и освобождает COM-объекты. Повторный вызов игнорируется.
        /// </summary>
        public void Dispose() {
            if (_disposed)
                return;
            _disposed = true;

            // Освобождаем листы до закрытия книги
            for (int i = 0; i < _openedSheets.Count; i++) {
                ReleaseComObject(_openedSheets[i]);
            }
            _openedSheets.Clear();

            try {
                if (_workbook != null)
                    _workbook.Close(Type.Missing, Type.Missing, Type.Missing);
            }
            catch {
                // Книга могла быть уже закрыта/изменена — всё равно гасим Excel ниже
            }

            ReleaseComObject(_sheets);
            _sheets = null;

            ReleaseComObject(_workbook);
            _workbook = null;

            try {
                if (_application != null)
                    _application.Quit();
            }
            catch {
            }

            ReleaseComObject(_application);
            _application = null;

            // Двухпроходный GC — стандартный приём против утечек COM-объектов Excel
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion

        #region | Private Methods |
        private static void ReleaseComObject(object comObject)
        {
            if (comObject != null && Marshal.IsComObject(comObject))
            {
                try
                {
                    Marshal.FinalReleaseComObject(comObject);
                }
                catch
                {
                }
            }
        }
        #endregion
    }
}
