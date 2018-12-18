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

        public ClosedExcelDataAccess(string workbookName, byte[] workbookData)
        {
            _workbookName = Path.GetFileName(workbookName);
            var workbookPath = Path.ChangeExtension(Path.GetTempFileName(), "xlsx");
            File.WriteAllBytes(workbookPath, workbookData);
            _workbook = new XLWorkbook(workbookPath)
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
            if (!_workbook.TryGetWorksheet(workSheetName, out var worksheet))
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
                        $"The cell address {cellAddress} did not return anything. Are you sure the address is correct?";
                    throw new ArgumentException(message);
                }
                return cell.GetValue<string>();
            }
        }

        public string GetValue(string cellAddress)
        {
            return GetValue("DataReadSheet", cellAddress).Trim();
        }
    }
}
