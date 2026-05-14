using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Helpers
{
    static class LoggerHelper
    {
        public static ILogger GetLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }
    }
}
