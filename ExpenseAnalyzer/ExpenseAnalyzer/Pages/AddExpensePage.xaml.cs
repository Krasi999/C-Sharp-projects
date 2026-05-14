namespace ExpenseAnalyzer.Pages;

public partial class AddExpensePage : ContentPage
{
    public AddExpensePage()
    {
        InitializeComponent();
    }

    async void FoodClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EnterAmountPage("Food"));
    }

    async void TransportClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EnterAmountPage("Transport"));
    }

    async void RentClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EnterAmountPage("Rent"));
    }

    async void LeasingClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EnterAmountPage("Leasing"));
    }

    async void EntertainmentClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EnterAmountPage("Entertainment"));
    }

    async void OtherClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EnterAmountPage("Other"));
    }
}