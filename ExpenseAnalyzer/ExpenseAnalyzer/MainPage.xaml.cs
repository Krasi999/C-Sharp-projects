using ExpenseAnalyzer.Pages;
using ExpenseAnalyzer.Models;

namespace ExpenseAnalyzer;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var expenses = App.Database.GetExpenses();

        double total = expenses
            .Where(e => e.Date.Month == DateTime.Now.Month)
            .Sum(e => e.Amount);

        totalLabel.Text = $"Total: {total} €";
    }

    async void OnAddExpense(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddExpensePage());
    }

    async void OnListExpenses(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExpenseListPage());
    }

    async void OnChart(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChartPage());
    }
}