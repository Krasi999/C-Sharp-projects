using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WelcomeExtended.Helpers;

namespace WelcomeExtended.Others
{
    internal class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");

        public static void Log(string error)
        {
            logger.LogError(error);
        }

        public static void Log2(string error)
        {
            Console.WriteLine("- DELEGATES -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        }
    }
}
