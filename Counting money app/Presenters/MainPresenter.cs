using MoneyCounterApp.Models;
using MoneyCounterApp.Models.Interfaces;
using MoneyCounterApp.Services;
using MoneyCounterApp.Views;
using System;

namespace MoneyCounterApp.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly FileService _fileService;
        private readonly XmlParser _xmlParser;
        private readonly LcmsParser _lcmsParser;
        private readonly PdfExporter _pdfExporter;
        private readonly ExcelExporter _excelExporter;
        private readonly CsvExporter _csvExporter;


        private MoneyReport _currentReport;

        public MainPresenter(IMainView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _fileService = new FileService();
            _xmlParser = new XmlParser();
            _lcmsParser = new LcmsParser();
            _pdfExporter = new PdfExporter();
            _excelExporter = new ExcelExporter();
            _csvExporter = new CsvExporter();

            _currentReport = new MoneyReport();
        }

        public void LoadXml()
        {
            try
            {
                _view.UpdateStatus("Loading XML file...");
                var filePath = _fileService.OpenFileDialog("XML Files (*.xml)|*.xml|All files (*.*)|*.*");

                if (string.IsNullOrEmpty(filePath))
                {
                    _view.UpdateStatus("Ready");
                    return;
                }

                _currentReport = _xmlParser.ParseXml(filePath);
                _view.DisplayReport(_currentReport);
                _view.UpdateStatus($"Loaded {System.IO.Path.GetFileName(filePath)}");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Failed to load XML: {ex.Message}", "Error", MessageBoxIcon.Error);
                _view.UpdateStatus("Load failed");
            }
        }

        public void LoadLcmsText()
        {
            try
            {
                _view.UpdateStatus("Loading LCMS text file...");
                var filePath = _fileService.OpenFileDialog("Text Files (*.txt)|*.txt|All files (*.*)|*.*");

                if (string.IsNullOrEmpty(filePath))
                {
                    _view.UpdateStatus("Ready");
                    return;
                }

                var text = _fileService.ReadTextFile(filePath);
                _currentReport = _lcmsParser.ParseText(text, filePath);
                _view.DisplayReport(_currentReport);
                _view.UpdateStatus($"Loaded {System.IO.Path.GetFileName(filePath)}");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Failed to load LCMS text: {ex.Message}", "Error", MessageBoxIcon.Error);
                _view.UpdateStatus("Load failed");
            }
        }

        public void ExportCsv()
        {
            Export(_csvExporter, "CSV Files (*.csv)|*.csv", "money_report.csv");
        }

        public void ExportExcel()
        {
            Export(_excelExporter, "Excel Files (*.xlsx)|*.xlsx", "money_report.xlsx");
        }

        public void ExportPdf()
        {
            Export(_pdfExporter, "PDF Files (*.pdf)|*.pdf", "money_report.pdf");
        }

        private void Export(IReportExporter exporter, string filter, string defaultFileName)
        {
            try
            {
                if (_currentReport == null || _currentReport.Notes.Count == 0)
                {
                    _view.ShowMessage("No data to export", "Warning", MessageBoxIcon.Warning);
                    return;
                }

                _view.UpdateStatus("Preparing export...");
                var defaultName = $"money_report_{_currentReport.Location?.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}";
                var filePath = _fileService.SaveFileDialog(filter, $"{defaultName}.{filter.Split('|')[0].Split('.')[1]}");

                if (string.IsNullOrEmpty(filePath))
                {
                    _view.UpdateStatus("Ready");
                    return;
                }

                exporter.Export(_currentReport, filePath);
                _view.ShowMessage($"File saved successfully:\n{filePath}", "Success");
                _view.UpdateStatus($"Exported to {System.IO.Path.GetFileName(filePath)}");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Failed to export: {ex.Message}", "Error", MessageBoxIcon.Error);
                _view.UpdateStatus("Export failed");
            }
        }

        public void Refresh()
        {
            if (string.IsNullOrEmpty(_currentReport.FilePath))
            {
                _view.ShowMessage("No file to refresh", "Warning", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _view.UpdateStatus("Refreshing data...");
                if (_currentReport.FilePath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    _currentReport = _xmlParser.ParseXml(_currentReport.FilePath);
                }
                else if (_currentReport.FilePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    var text = _fileService.ReadTextFile(_currentReport.FilePath);
                    _currentReport = _lcmsParser.ParseText(text, _currentReport.FilePath);
                }

                _view.DisplayReport(_currentReport);
                _view.UpdateStatus("Data refreshed");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Failed to refresh: {ex.Message}", "Error", MessageBoxIcon.Error);
                _view.UpdateStatus("Refresh failed");
            }
        }

        public void Clear()
        {
            _currentReport = new MoneyReport();
            _view.ClearDisplay();
            _view.UpdateStatus("Ready");
        }
    }
}