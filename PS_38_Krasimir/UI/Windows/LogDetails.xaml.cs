using System.Windows;

namespace UI.Windows
{
    public partial class LogDetailsWindow : Window
    {
        public LogDetailsWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}