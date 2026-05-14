using System;
using System.Collections.Generic;
using System.Text;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("User: " + _viewModel.Name);
            Console.WriteLine("Role: " + _viewModel.Role);
        }

        public void FullInfo()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("User: " + _viewModel.Name);
            Console.WriteLine("User's facNumber: " + _viewModel.FacNumber);
            Console.WriteLine("User's email: " + _viewModel.Email);
            //Console.WriteLine("User's password: " + _viewModel.Password);
            Console.WriteLine("Role: " + _viewModel.Role);
        }
        public void DisplayError()
        {
            throw new Exception("Text of the exception!");
        }
    }
}
