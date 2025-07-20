namespace MoneyCounterApp.Models.Interfaces
{
    public interface IReportExporter
    {
        void Export(MoneyReport report, string filePath);
    }
}