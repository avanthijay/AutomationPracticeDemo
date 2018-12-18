using System;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace AutomationPracticeDemo.Data
{
    public class ClosedExcelDataAccess : IExcelDataAccess, IDisposable
    {
        private readonly XLWorkbook _workbook;
        private readonly string _workbookName;
        private readonly string _workbookPath;

        public ClosedExcelDataAccess(string workbookName, byte[] workbookData)
        {
            _workbookName = Path.GetFileName(workbookName);
            _workbookPath = Path.ChangeExtension(Path.GetTempFileName(), "xlsx");
            File.WriteAllBytes(_workbookPath, workbookData);
            _workbook = new XLWorkbook(_workbookPath)
            {
                EventTracking = XLEventTracking.Disabled
            };
        }

        public void Dispose()
        {
            _workbook.Dispose();
        }


        public string GetValue(string workSheetName, string cellAddress)
        {
            IXLWorksheet worksheet;
            if (!_workbook.TryGetWorksheet(workSheetName, out worksheet))
            {
                var worksheetNames = string.Join(", ", _workbook.Worksheets.Select(x => x.Name));
                var message =
                    $"Cound not find a worksheet called{workSheetName} in the Excel file called {_workbookName}, Possible names are {worksheetNames}, ";
                throw new ArgumentException(message);
            }
            using (worksheet)
            {
                var cell = worksheet.Cell(cellAddress);
                if (cell == null)
                {
                    var message =
                        string.Format(
                            "The cell address {0} did not return anything. Are you sure the address is correct?",
                            cellAddress);
                    throw new ArgumentException(message);
                }
                return cell.GetValue<string>();
            }
        }
    }
}
