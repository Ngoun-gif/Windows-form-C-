using System.Collections.Generic;

namespace MoneyCounterApp.Models
{
    public class MoneyReport
    {
        public string Source { get; set; } = "Unknown";
        public string MachineId { get; set; } = "N/A";
        public string Location { get; set; } = "N/A";
        public string Operator { get; set; } = "N/A";
        public string Timestamp { get; set; } = "N/A";
        public string Currency { get; set; } = "N/A";
        public int TotalNotes { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "N/A";
        public string MachineModel { get; set; } = "N/A";
        public List<MoneyNote> Notes { get; set; } = new List<MoneyNote>();
        public string FilePath { get; set; } = string.Empty;
    }
}