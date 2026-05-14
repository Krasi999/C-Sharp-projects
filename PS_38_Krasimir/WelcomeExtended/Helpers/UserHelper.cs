using System;
using System.Collections.Generic;
using System.Text;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    static class UserHelper
    {
        public static string ToUserString(this User user)
        {
            return $"ID: {user.Id}, Name: {user.Name}, Role: {user.Role}";
        }

        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            string errorMssg = "";

            if (string.IsNullOrWhiteSpace(name)) errorMssg += "The name cannot be empty.\n";
            if (string.IsNullOrWhiteSpace(password)) errorMssg += "The password cannot be empty.\n";


            if (!string.IsNullOrEmpty(errorMssg))
            {
                Console.WriteLine(errorMssg.Trim());
                return false;
            }

            bool userExists = userData.ValidateUser(name, password);

            if (!userExists)
            {
                Console.WriteLine("Invalid name or password!");
                return false;
            }

            return true;
        }

        public static User GetUser(this UserData data,string name, string password)
        { 
            return data.GetUser(name, password);
        }

    }
}
