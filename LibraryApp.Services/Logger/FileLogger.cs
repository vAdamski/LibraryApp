using LibraryApp.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Services
{
    public class FileLogger : ILogger
    {
        private readonly string _filename = "logs.txt";

        /// <summary>
        /// Log error message to file
        /// </summary>
        /// <param name="message">Message to log</param>
        public void Log(string message)
        {
            if(File.Exists(_filename))
            {
                using var streamWriter = File.AppendText(_filename);

                streamWriter.WriteLine("Error log: " + message);
            }
            else
            {
                using var streamWriter = File.CreateText(_filename);

                streamWriter.WriteLine("Error log: " + message);
            }
        }
    }
}
