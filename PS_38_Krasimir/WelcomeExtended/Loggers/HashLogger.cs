using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace WelcomeExtended.Loggers
{
    internal class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            // This logger does not support scopes.
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // This logger is always enabled.
            return true; ;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId,
            TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red; 
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;

        }

        //Метод за принтиране на всички записани съобщения
        public void PrintAllLogs()
        {
            Console.WriteLine("---- ALL LOGS ----");
            foreach (var log in _logMessages)
            {
                Console.WriteLine($"EventId: {log.Key} -> Massage: {log.Value}");
            }
            Console.WriteLine("------------------");
        }

        //Метод за принтиране на съобщение по дадено eventId
        public void PrintLogById(int eventId)
        {
            if (_logMessages.TryGetValue(eventId, out string message))
            {
                Console.WriteLine($"EventId: {eventId} ->Message: {message}");
            }
            else
            {
                Console.WriteLine($"No log found with EventId: {eventId}");
            }
        }

        //Метод за изтриване на съобщение по дадено eventId
        public void DeleteLogById(int eventId)
        {
            if(_logMessages.TryRemove(eventId, out _))
            {
                Console.WriteLine($"Log with EventId {eventId} was deleted!");
            }
            else
            {
                Console.WriteLine($"No log found with EventId: {eventId}");
            }
        }
    }
}
