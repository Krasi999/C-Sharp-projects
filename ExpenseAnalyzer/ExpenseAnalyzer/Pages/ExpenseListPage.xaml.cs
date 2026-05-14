using ExpenseAnalyzer.Models;

namespace ExpenseAnalyzer.Pages;

public partial class ExpenseListPage : ContentPage
{
    public ExpenseListPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadExpenses();
    }

    private void LoadExpenses()
    {
        var expenses = App.Database.GetExpenses()
            .Where(e => e.Date.Month == DateTime.Now.Month && 
                        !string.IsNullOrEmpty(e.Category) && 
                        e.Amount > 0)
            .OrderByDescending(e => e.Date)
            .ToList();

        expenseList.ItemsSource = expenses;
    }

    private async void OnExpenseSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedExpense = e.CurrentSelection.FirstOrDefault() as Expense;
        if (selectedExpense == null) return;

        bool answer = await DisplayAlert("Delete", $"Do you want to delete this expense?", "Yes", "No");

        if (answer)
        {
            int result = App.Database.DeleteExpense(selectedExpense.Id);

            if (result > 0)
            {
                await DisplayAlert("Successful", "Deleted successfully!", "OK");
                LoadExpenses();
            }
            else
            {
                await DisplayAlert("Error", $"There aren't any record with Id: {selectedExpense.Id}", "OK");
            }
        }

        expenseList.SelectedItem = null;
    }
}