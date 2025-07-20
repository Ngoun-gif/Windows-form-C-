using System;
using System.Collections.Generic;
using System.Linq;
using MoneyCounterApp.Models;

namespace MoneyCounterApp.Services
{
    public class LcmsParser
    {
        public MoneyReport ParseText(string text, string filePath)
        {
            var report = new MoneyReport
            {
                Source = "LCMS",
                FilePath = filePath,
                Status = text.Contains("disconnect", StringComparison.OrdinalIgnoreCase) ? "Disconnected" : "Connected",
                MachineModel = "LCMS"
            };

            var lines = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(l => l.Trim())
                           .Where(l => !string.IsNullOrWhiteSpace(l))
                           .ToList();

            bool tableStarted = false;

            foreach (var line in lines)
            {
                // Check for table header
                if (line.Contains('|') && (line.Contains("Den", StringComparison.OrdinalIgnoreCase) ||
                                          line.Contains("Pcs", StringComparison.OrdinalIgnoreCase) ||
                                          line.Contains("Tot", StringComparison.OrdinalIgnoreCase)))
                {
                    tableStarted = true;
                    continue;
                }

                // Parse table rows
                if (tableStarted && line.Contains('|'))
                {
                    var parts = line.Split('|')
                                   .Select(p => p.Trim())
                                   .Where(p => !string.IsNullOrWhiteSpace(p))
                                   .ToList();

                    // Skip separator lines
                    if (parts.All(p => p.All(c => c == '-' || char.IsWhiteSpace(c))))
                        continue;

                    // Parse denomination row
                    if (parts.Count >= 4 && int.TryParse(parts[0], out _))
                    {
                        try
                        {
                            report.Notes.Add(new MoneyNote
                            {
                                Denomination = decimal.Parse(parts[1]),
                                Count = int.Parse(parts[2]),
                                Stacker = parts.Count > 4 ? parts[4] : "N/A"
                            });
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    // Parse summary line
                    else if (line.Contains("total", StringComparison.OrdinalIgnoreCase) &&
                             line.Contains("value", StringComparison.OrdinalIgnoreCase))
                    {
                        var totalParts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (totalParts.Length >= 4)
                        {
                            if (int.TryParse(totalParts[2], out var totalNotes))
                                report.TotalNotes = totalNotes;

                            if (decimal.TryParse(totalParts[4], out var totalAmount))
                                report.TotalAmount = totalAmount;
                        }
                    }
                }
            }

            // If no notes found, try alternative parsing
            if (report.Notes.Count == 0)
            {
                ParseAlternativeFormat(lines, report);
            }

            return report;
        }

        private void ParseAlternativeFormat(List<string> lines, MoneyReport report)
        {
            foreach (var line in lines)
            {
                // Try to find denomination lines like "100 x 5 = 500"
                if (line.Contains('x') && line.Contains('='))
                {
                    var parts = line.Split(new[] { ' ', 'x', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 3 &&
                        decimal.TryParse(parts[0], out var denom) &&
                        int.TryParse(parts[1], out var count))
                    {
                        report.Notes.Add(new MoneyNote
                        {
                            Denomination = denom,
                            Count = count,
                            Stacker = "N/A"
                        });
                    }
                }

                // Try to find totals
                if (line.Contains("total", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 1)
                    {
                        if (line.Contains("notes", StringComparison.OrdinalIgnoreCase) &&
                            int.TryParse(parts.Last(), out var totalNotes))
                        {
                            report.TotalNotes = totalNotes;
                        }
                        else if ((line.Contains("amount", StringComparison.OrdinalIgnoreCase) ||
                                 line.Contains("value", StringComparison.OrdinalIgnoreCase)) &&
                                decimal.TryParse(parts.Last(), out var totalAmount))
                        {
                            report.TotalAmount = totalAmount;
                        }
                    }
                }
            }
        }
    }
}