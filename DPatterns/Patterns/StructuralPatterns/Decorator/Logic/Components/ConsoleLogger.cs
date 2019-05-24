using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.StructuralPatterns.Decorator.Logic
{
    public class ConsoleLogger : Logger
    {
        public override string _message { get; set; }
        public ConsoleLogger(string message): base(message) { }
        public override void LogMessage()
        {
            Console.WriteLine(this._message);
        }
    }
}
