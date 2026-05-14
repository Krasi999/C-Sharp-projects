using DataLayer.Database;
using DataLayer.Model;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;
using Welcome.Others;

class Program
{
    static void Main()
    {
        using (var db = new DatabaseContext())
        {
            db.Database.EnsureCreated();
        }

        while (true)
        {
            Console.WriteLine("\n1. All users - list");
            Console.WriteLine("2. Add user");
            Console.WriteLine("3. Delete user");
            Console.WriteLine("4. Login");
            Console.WriteLine("5. Exit");
            Console.Write("Select option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": GetAllUsers(); break;
                case "2": AddUser(); break;
                case "3": DeleteUser(); break;
                case "4": Login(); break;
                case "5": return;
            }
        }
    }

    static void GetAllUsers()
    {
        using var db = new DatabaseContext();
        var users = db.Users.ToList();

        foreach (var u in users)
        {
            Console.WriteLine($"{u.Id}: {u.Name} | {u.Role} | Valid due: {u.Expires}");
        }
    }

    static void AddUser()
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();

        Console.Write("Password: ");
        var pass = Console.ReadLine();

        using var db = new DatabaseContext();

        db.Users.Add(new DatabaseUser
        {
            Name = name,
            Password = pass,
            Role = UserRolesEnum.STUDENT,
            Expires = DateTime.Now.AddYears(1),
            FacNumber = "000000000",
            Email = "example@tu-sofia.bg"
        });

        db.Logs.Add(new DatabaseLog { Message = $"Added user: {name}" });
        db.SaveChanges();
    }

    static void DeleteUser()
    {
        Console.Write("User's name to delete: ");
        var name = Console.ReadLine();

        using var db = new DatabaseContext();
        var user = db.Users.FirstOrDefault(u => u.Name == name);

        if (user != null)
        {
            db.Users.Remove(user);
            db.Logs.Add(new DatabaseLog { Message = $"Deleted users: {name}" });
            db.SaveChanges();
            Console.WriteLine("Successfully deleted.");
        }
        else
        {
            Console.WriteLine("No such user.");
        }
    }

    static void Login()
    {
        Console.Write("User: ");
        var user = Console.ReadLine();

        Console.Write("Password: ");
        var pass = Console.ReadLine();

        using var db = new DatabaseContext();

        bool valid = db.Users
            .AsEnumerable().Any(u => u.Name == user && u.Password == pass);

        Console.WriteLine(valid ? "Valid user" : "Invalid user");

        db.Logs.Add(new DatabaseLog
        {
            Message = valid ? $"Successfull login: {user}" : $"Unsuccessfull login: {user}"
        });

        db.SaveChanges();
    }
}