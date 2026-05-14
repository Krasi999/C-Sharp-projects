using ExpenseAnalyzer.Models;
using SQLite;

namespace ExpenseAnalyzer.Database
{
    public class ExpenseDatabase
    {
        SQLiteConnection database;

        public ExpenseDatabase(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Expense>();
        }

        public List<Expense> GetExpenses()
        {
            return database.Table<Expense>().ToList();
        }

        public int SaveExpense(Expense expense)
        {
            if (expense.Id != 0)
            {
                return database.Update(expense); 
            }
            else
            {
                return database.Insert(expense); 
            }
        }

        public int DeleteExpense(int id)
        {
            return database.Table<Expense>().Delete(x => x.Id == id);
        }
    }
}