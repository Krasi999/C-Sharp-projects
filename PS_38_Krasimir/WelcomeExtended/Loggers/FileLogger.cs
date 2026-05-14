using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;

namespace WelcomeExtended.Loggers
{
    internal class FileLogger : ILogger
    {
        private readonly string _name;
        private readonly string _filePath;

        public FileLogger(string name, string filePath)
        {
            _name = name;
            _filePath = filePath;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId,
            TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);

            var logMessage = new StringBuilder();
            logMessage.AppendLine("----- LOGGER -----");
            logMessage.AppendLine($"Date: {DateTime.Now}");
            logMessage.AppendLine($"Level: {logLevel}");
            logMessage.AppendLine($"EventId: {eventId.Id}");
            logMessage.AppendLine($"Logger: {_name}");
            logMessage.AppendLine($"Message: {message}");
            logMessage.AppendLine("------------------");
            logMessage.AppendLine();

            
            File.AppendAllText(_filePath, logMessage.ToString());
        }
    }
}