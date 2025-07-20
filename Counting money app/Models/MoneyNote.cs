namespace MoneyCounterApp.Models
{
    public class MoneyNote
    {
        public decimal Denomination { get; set; }
        public int Count { get; set; }
        public decimal Amount => Denomination * Count;
        public string Stacker { get; set; } = "N/A";
    }
}