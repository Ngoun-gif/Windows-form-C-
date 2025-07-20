using ClosedXML.Excel;
using MoneyCounterApp.Models;
using MoneyCounterApp.Models.Interfaces;
using System;
using System.IO;

namespace MoneyCounterApp.Services
{
    public class ExcelExporter : IReportExporter
    {
        public void Export(MoneyReport report, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Money Report");

                // Title
                worksheet.Cell(1, 1).Value = "Money Count Report";
                worksheet.Range(1, 1, 1, 4).Merge().Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Report Info
                worksheet.Cell(3, 1).Value = $"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                worksheet.Cell(4, 1).Value = $"Source: {report.Source} - {Path.GetFileName(report.FilePath)}";

                // Transaction Details
                int row = 6;
                worksheet.Cell(row, 1).Value = "Transaction Details";
                worksheet.Cell(row, 1).Style.Font.Bold = true;
                worksheet.Cell(row, 1).Style.Font.FontSize = 12;
                row++;

                AddKeyValue(worksheet, ref row, "Machine ID", report.MachineId);
                // Add other properties similarly...

                // Denomination Table
                row += 2;
                worksheet.Cell(row, 1).Value = "Denominations";
                worksheet.Cell(row, 1).Style.Font.Bold = true;
                row++;

                // Headers
                worksheet.Cell(row, 1).Value = "Denomination";
                worksheet.Cell(row, 2).Value = "Count";
                worksheet.Cell(row, 3).Value = "Amount";
                worksheet.Cell(row, 4).Value = "Stacker";
                worksheet.Range(row, 1, row, 4).Style.Font.Bold = true;
                worksheet.Range(row, 1, row, 4).Style.Fill.BackgroundColor = XLColor.LightGray;
                row++;

                // Data Rows
                foreach (var note in report.Notes)
                {
                    worksheet.Cell(row, 1).Value = $"{report.Currency} {note.Denomination}";
                    worksheet.Cell(row, 2).Value = note.Count;
                    worksheet.Cell(row, 3).Value = $"{report.Currency} {note.Amount}";
                    worksheet.Cell(row, 4).Value = note.Stacker;
                    row++;
                }

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(filePath);
            }
        }

        private void AddKeyValue(IXLWorksheet worksheet, ref int row, string key, string value)
        {
            if (value != "N/A")
            {
                worksheet.Cell(row, 1).Value = $"{key}:";
                worksheet.Cell(row, 1).Style.Font.Bold = true;
                worksheet.Cell(row, 2).Value = value;
                row++;
            }
        }
    }
}