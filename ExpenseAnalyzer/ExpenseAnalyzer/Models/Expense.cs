using SQLite; 

namespace ExpenseAnalyzer.Models
{
    [Table("expenses")] 
    public class Expense
    {
        [PrimaryKey, AutoIncrement, Column("_id")] 
        public int Id { get; set; }

        public string Category { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}