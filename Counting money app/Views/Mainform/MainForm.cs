using MoneyCounterApp.Models;
using MoneyCounterApp.Presenters;
using System;
using System.Windows.Forms;

namespace MoneyCounterApp.Views
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainPresenter _presenter;

        public MainForm()
        {
            InitializeComponent();

            // Initialize data grid view columns
            dataGridView.Columns.Add("Denomination", "Denomination");
            dataGridView.Columns.Add("Count", "Count");
            dataGridView.Columns.Add("Amount", "Amount");
            dataGridView.Columns.Add("Stacker", "Stacker");

            // Set column styles
            dataGridView.Columns["Denomination"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["Stacker"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set column widths
            dataGridView.Columns["Denomination"].Width = 150;
            dataGridView.Columns["Count"].Width = 100;
            dataGridView.Columns["Amount"].Width = 150;
            dataGridView.Columns["Stacker"].Width = 100;

            // Initialize presenter
            _presenter = new MainPresenter(this);
        }

        // Implement IMainView interface methods
        public void DisplayReport(MoneyReport report)
        {
            // Update file info
            fileInfoLabel.Text = $"Loaded: {System.IO.Path.GetFileName(report.FilePath)}\n" +
                               $"Source: {report.Source}\n" +
                               $"Status: {report.Status}";

            // Update summary
            summaryLabel.Text = $"Currency: {report.Currency} | " +
                              $"Total Amount: {report.TotalAmount} | " +
                              $"Total Notes: {report.TotalNotes}";

            // Update data grid
            dataGridView.Rows.Clear();
            foreach (var note in report.Notes)
            {
                dataGridView.Rows.Add(
                    $"{report.Currency} {note.Denomination}",
                    note.Count,
                    $"{report.Currency} {note.Amount}",
                    note.Stacker
                );
            }

            // Update raw text
            rawTextBox.Text = $"Source: {report.Source}\n" +
                            $"File: {report.FilePath}\n\n" +
                            $"Machine ID: {report.MachineId}\n" +
                            $"Location: {report.Location}\n" +
                            $"Operator: {report.Operator}\n" +
                            $"Timestamp: {report.Timestamp}\n" +
                            $"Currency: {report.Currency}\n" +
                            $"Total Notes: {report.TotalNotes}\n" +
                            $"Total Amount: {report.TotalAmount}\n" +
                            $"Status: {report.Status}\n\n" +
                            "Denominations:\n";

            foreach (var note in report.Notes)
            {
                rawTextBox.Text += $"{note.Denomination} x {note.Count} = {note.Amount} ({note.Stacker})\n";
            }

            // Enable export buttons
            exportCsvButton.Enabled = true;
            exportExcelButton.Enabled = true;
            exportPdfButton.Enabled = true;
            refreshButton.Enabled = true;
            clearButton.Enabled = true;
        }

        public void ClearDisplay()
        {
            fileInfoLabel.Text = "No file loaded";
            summaryLabel.Text = string.Empty;
            dataGridView.Rows.Clear();
            rawTextBox.Text = string.Empty;

            // Disable export buttons
            exportCsvButton.Enabled = false;
            exportExcelButton.Enabled = false;
            exportPdfButton.Enabled = false;
            refreshButton.Enabled = false;
            clearButton.Enabled = false;
        }

        public void ShowMessage(string message, string title = "Information", MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, icon);
        }

        public void UpdateStatus(string message)
        {
            statusLabel.Text = message;
            statusStrip.Refresh();
        }

        // Event handlers
        private void LoadXmlButton_Click(object sender, EventArgs e)
        {
            _presenter.LoadXml();
        }

        

        private void LoadLcmsTextButton_Click(object sender, EventArgs e)
        {
            _presenter.LoadLcmsText();
        }

        private void ExportCsvButton_Click(object sender, EventArgs e)
        {
            _presenter.ExportCsv();
        }

        private void ExportExcelButton_Click(object sender, EventArgs e)
        {
            _presenter.ExportExcel();
        }

        private void ExportPdfButton_Click(object sender, EventArgs e)
        {
            _presenter.ExportPdf();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            _presenter.Refresh();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _presenter.Clear();
        }

       
    }

    public interface IMainView
    {
        void DisplayReport(MoneyReport report);
        void ClearDisplay();
        void ShowMessage(string message, string title = "Information", MessageBoxIcon icon = MessageBoxIcon.Information);
        void UpdateStatus(string message);
    }
}