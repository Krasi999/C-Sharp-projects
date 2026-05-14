using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Name = "Krasimir";
            user.Password = "0123456789";
            user.FacNumber = "121223008";
            user.Email = "krasi@gmail.com";
            user.Role = UserRolesEnum.ADMIN;

            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);

            userView.Display();
            Console.WriteLine();
            userView.FullInfo();
            Console.ReadKey();
        }
    }
}
