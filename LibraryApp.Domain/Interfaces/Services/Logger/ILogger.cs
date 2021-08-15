using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain
{
    public interface ILogger
    {
        /// <summary>
        /// Log message
        /// </summary>
        /// <param name="message">Message to log</param>
        void Log(string message);
    }
}
