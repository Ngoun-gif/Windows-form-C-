using MoneyCounterApp.Models;
using MoneyCounterApp.Models.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MoneyCounterApp.Services
{
    public class CsvExporter : IReportExporter
    {
        public void Export(MoneyReport report, string filePath)
        {
            var csvContent = new StringBuilder();

            // Add metadata
            csvContent.AppendLine("Property,Value");
            csvContent.AppendLine($"Source,{report.Source}");
            csvContent.AppendLine($"Machine ID,{report.MachineId}");
            csvContent.AppendLine($"Location,{report.Location}");
            csvContent.AppendLine($"Operator,{report.Operator}");
            csvContent.AppendLine($"Timestamp,{report.Timestamp}");
            csvContent.AppendLine($"Currency,{report.Currency}");
            csvContent.AppendLine($"Total Notes,{report.TotalNotes}");
            csvContent.AppendLine($"Total Amount,{report.TotalAmount}");
            csvContent.AppendLine($"Status,{report.Status}");
            csvContent.AppendLine($"Machine Model,{report.MachineModel}");
            csvContent.AppendLine();

            // Add notes header
            csvContent.AppendLine("Denomination,Count,Amount,Stacker");

            // Add notes
            foreach (var note in report.Notes)
            {
                csvContent.AppendLine($"{note.Denomination},{note.Count},{note.Amount},{note.Stacker}");
            }

            File.WriteAllText(filePath, csvContent.ToString());
        }
    }
}