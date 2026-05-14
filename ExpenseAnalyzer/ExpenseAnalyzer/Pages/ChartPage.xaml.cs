using ExpenseAnalyzer.Models;
using Microcharts;
using SkiaSharp;

namespace ExpenseAnalyzer.Pages;

public partial class ChartPage : ContentPage
{
    public ChartPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(100); 
        LoadChart();
    }

    void LoadChart()
    {
        var expenses = App.Database.GetExpenses()
            .Where(e => e.Date.Month == DateTime.Now.Month)
            .ToList();

        double total = expenses.Sum(e => e.Amount);

        var categories = new[] { "Food", "Transport", "Rent", "Leasing", "Entertainment", "Other" };
        var colors = new[] { "#FF6384", "#36A2EB", "#4BC0C0", "#FFCE56", "#9966FF", "#C9CBCF" };

        List<ChartEntry> entries = new();

        legendStack.Children.Clear();

        var labelsToRemove = chartContainer.Children.Where(c => c is Label).ToList();
        foreach (var lbl in labelsToRemove)
            chartContainer.Children.Remove(lbl);

        double centerX = chartContainer.Width / 2;
        double centerY = chartContainer.Height / 2;

        double radiusInside = centerX * 0.35;
        double radiusOutside = centerX * 0.58;

        double currentAngle = -90;

        for (int i = 0; i < categories.Length; i++)
        {
            double catSum = expenses.Where(e => e.Category == categories[i]).Sum(e => e.Amount);
            double percent = total > 0 ? (catSum / total) * 100 : 0;

            if (catSum > 0)
            {
                entries.Add(new ChartEntry((float)catSum)
                {
                    Color = SKColor.Parse(colors[i])
                });

                double sweepAngle = (catSum / total) * 360;
                double middleAngle = currentAngle + sweepAngle / 2;
                double radians = middleAngle * Math.PI / 180;

                bool smallSlice = percent < 6;

                double radius = smallSlice ? radiusOutside : radiusInside;

                double x = centerX + radius * Math.Cos(radians);
                double y = centerY + radius * Math.Sin(radians);

                var percentLabel = new Label
                {
                    Text = $"{percent:0}%",
                    FontSize = 20,
                    FontAttributes = FontAttributes.Bold,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = smallSlice ? Colors.Black : Colors.White
                };

                AbsoluteLayout.SetLayoutBounds(percentLabel, new Rect(x - 20, y - 15, 50, 40));
                chartContainer.Children.Add(percentLabel);

                currentAngle += sweepAngle;
            }

            AddLegendItem(categories[i], colors[i]);
        }

        chartView.Chart = new PieChart
        {
            Entries = entries,
            LabelMode = LabelMode.None,
            GraphPosition = GraphPosition.Center
        };
    }

    void AddLegendItem(string name, string colorHex)
    {
        var row = new HorizontalStackLayout { Spacing = 15 };

        row.Children.Add(new BoxView
        {
            Color = Color.FromArgb(colorHex),
            WidthRequest = 24,
            HeightRequest = 24,
            CornerRadius = 12
        });

        row.Children.Add(new Label
        {
            Text = name,
            FontSize = 20,
            VerticalOptions = LayoutOptions.Center
        });

        legendStack.Children.Add(row);
    }
}