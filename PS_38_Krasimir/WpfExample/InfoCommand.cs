using System;
using System.Windows;
using System.Windows.Input;

namespace WpfExample
{
    public class InfoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Hello, world!");

            if (parameter != null && parameter.ToString() == "OpenWindow")
            {
                NamesWindow namesWin = new NamesWindow();
                namesWin.Show();
            }
        }
    }
}