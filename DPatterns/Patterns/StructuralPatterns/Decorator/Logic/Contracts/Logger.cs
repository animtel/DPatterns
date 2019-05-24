using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.StructuralPatterns.Decorator
{
    public abstract class Logger
    {
        public abstract string _message { get; set; }
        public Logger(string message)
        {
            _message = message;
        }
        public abstract void LogMessage();
    }
}
