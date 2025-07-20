using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using MoneyCounterApp.Models;

namespace MoneyCounterApp.Services
{
    public class XmlParser
    {
        public MoneyReport ParseXml(string filePath)
        {
            var report = new MoneyReport
            {
                Source = "XML",
                FilePath = filePath
            };

            try
            {
                var doc = XDocument.Load(filePath);
                var root = doc.Root ?? throw new Exception("Empty XML document");

                // Parse metadata
                report.MachineId = GetElementValue(root, "machine_id");
                report.Location = GetElementValue(root, "location");
                report.Operator = GetElementValue(root, "operator");
                report.Timestamp = GetElementValue(root, "timestamp");
                report.Currency = GetElementValue(root, "currency");
                report.TotalNotes = int.Parse(GetElementValue(root, "total_notes") ?? "0");
                report.TotalAmount = decimal.Parse(GetElementValue(root, "total_amount") ?? "0");
                report.Status = GetElementValue(root, "status");

                // Parse denominations
                var denominations = root.Element("denominations");
                if (denominations == null)
                    throw new Exception("Missing denominations section");

                foreach (var note in denominations.Elements("note"))
                {
                    var denomination = note.Element("denomination")?.Value;
                    var count = note.Element("count")?.Value;
                    var amount = note.Element("amount")?.Value;

                    if (string.IsNullOrEmpty(denomination) || string.IsNullOrEmpty(count) || string.IsNullOrEmpty(amount))
                        continue;

                    report.Notes.Add(new MoneyNote
                    {
                        Denomination = decimal.Parse(denomination),
                        Count = int.Parse(count),
                        Stacker = note.Element("stacker")?.Value ?? "N/A"
                    });
                }

                return report;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to parse XML: {ex.Message}", ex);
            }
        }

        private string? GetElementValue(XElement parent, string elementName)
        {
            return parent.Element(elementName)?.Value;
        }
    }
}