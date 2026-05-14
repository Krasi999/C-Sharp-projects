using ExpenseAnalyzer.Database;

namespace ExpenseAnalyzer;

public partial class App : Application
{
    static ExpenseDatabase database;

    public static ExpenseDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new ExpenseDatabase(
                    Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "expenses.db3"));
            }

            return database;
        }
    }

    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}