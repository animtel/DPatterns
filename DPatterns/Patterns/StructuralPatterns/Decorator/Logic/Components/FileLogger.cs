using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.StructuralPatterns.Decorator.Logic
{
    public class FileLogger : Logger
    {
        public override string _message { get; set; }

        public FileLogger(string message, string filePath, string fileName): base(message)
        {

        }

        public override void LogMessage()
        {
            throw new NotImplementedException();
        }
    }
}
