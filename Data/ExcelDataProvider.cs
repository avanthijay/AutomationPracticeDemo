using AutomationPracticeDemo.Utilities;

namespace AutomationPracticeDemo.Data
{
    public class ExcelDataProvider
    {
        public static ClosedExcelDataAccess ExternalData = new ClosedExcelDataAccess("ExternalData.xlsx", ResourceController.ExternalData);
    }
}
