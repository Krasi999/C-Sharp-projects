using ExpenseAnalyzer.Models;

namespace ExpenseAnalyzer.Pages;

public partial class EnterAmountPage : ContentPage
{
    string category;

    public EnterAmountPage(string selectedCategory)
    {
        InitializeComponent();

        category = selectedCategory;

        categoryLabel.Text = selectedCategory;
    }

    void AddExpense(object sender, EventArgs e)
    {
        double amount = Convert.ToDouble(amountEntry.Text);

        Expense expense = new Expense
        {
            Category = category,
            Amount = amount,
            Date = DateTime.Now
        };

        App.Database.SaveExpense(expense);

        DisplayAlert("Success", "Expense Added!", "OK");

        Navigation.PopToRootAsync();
    }
}