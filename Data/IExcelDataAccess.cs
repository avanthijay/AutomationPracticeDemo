namespace AutomationPracticeDemo.Data
{
    internal interface IExcelDataAccess
    {
        string GetValue(string workSheetName, string cellAddress);
    }
}
