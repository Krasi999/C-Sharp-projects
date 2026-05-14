using MinimalMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MinimalMVVM.View
{
    public partial class MainWindow : Window
    {
        private readonly Presenter _upperVM = new Presenter();
        private readonly LowerPresenter _lowerVM = new LowerPresenter();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _upperVM;
        }

        private void SwitchViewModel_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;

            if (this.DataContext is Presenter)
            {
                this.DataContext = _lowerVM;
                button.Content = "Switch to UPPERCASE Mode";
            }
            else
            {
                this.DataContext = _upperVM;
                button.Content = "Switch to LowerCase Mode";
            }
        }
    }
}