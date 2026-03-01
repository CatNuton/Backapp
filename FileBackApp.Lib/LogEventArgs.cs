using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBackApp.Lib
{
    public class LogEventArgs : EventArgs
    {
        public string Message { get; }
        public ConsoleColor Color { get; }
        public LogEventArgs(string message, ConsoleColor color)
        {
            Message = message;
            Color = color;
        }
    }
}
