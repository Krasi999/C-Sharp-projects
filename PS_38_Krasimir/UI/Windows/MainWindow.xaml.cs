using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Windows;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenLogger_Click(object sender, RoutedEventArgs e)
        {
            LogsWindow logWin = new LogsWindow();
            logWin.Show();
        }
    }
}