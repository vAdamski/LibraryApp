using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;

namespace LibraryApp.Services
{
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Log message to console
        /// </summary>
        /// <param name="message">Message to log</param>
        public void Log(string message)
        {
            Console.WriteLine("Error log: " + message);
        }
    }
}
