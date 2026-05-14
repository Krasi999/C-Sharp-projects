using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var logger = new HashLogger("TestLogger");
            var fileLogger = new FileLogger("FileLogger", "log.txt");

            try
            {
                UserData userData = new UserData();

                User studentUser = new User()
                {
                    Name = "student",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                userData.AddUser(studentUser);

                User studentUser2 = new User()
                {
                    Name = "student2",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                userData.AddUser(studentUser2);

                User teacherUser2 = new User()
                {
                    Name = "teacher",
                    Password = "1234",
                    Role = UserRolesEnum.PROFESSOR
                };
                userData.AddUser(teacherUser2);

                User adminUser3 = new User()
                {
                    Name = "admin",
                    Password = "12345",
                    Role = UserRolesEnum.ADMIN
                };
                userData.AddUser(adminUser3);


                Console.Write("Enter the name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the password: ");
                string password = Console.ReadLine();

                if (userData.ValidateCredentials(name, password))
                {
                    var user = userData.GetUser(name, password);
                    Console.WriteLine("Successful log in");
                    Console.WriteLine(user.ToUserString());
                    fileLogger.Log(LogLevel.Information, new EventId(1), $"User {name} logged in.", null, (s, ex) => s.ToString());
                }
                else
                {
                    fileLogger.Log(LogLevel.Error, new EventId(2), $"Failed login attempt for {name}.", null, (s, ex) => s.ToString());
                }
            }

            catch (Exception e)
            {
                fileLogger.Log(LogLevel.Critical, new EventId(3), $"Critical error: {e.Message}", null, (s, ex) => s.ToString());
                Console.WriteLine($"{e.Message}");
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
                logger.Log(LogLevel.Warning, new EventId(1), e.Message, null, (s, ex) => s.ToString());
                logger.Log(LogLevel.Critical, new EventId(2), e.Message, null, (s, ex) => s.ToString());

                fileLogger.Log(LogLevel.Critical, new EventId(1), e.Message, null, (s, ex) => s.ToString());
                Console.WriteLine($"{e.Message}");
            }

            finally
            {
                Console.WriteLine("Executed in any case!");

                logger.PrintAllLogs();        // Принтира всички преди да направим изтриване
                logger.PrintLogById(1);       // Принтира по ID
                logger.DeleteLogById(1);      // Изтрива по ID
                logger.PrintAllLogs();        // Проверка след изтриване
            }

        }
    }
}

