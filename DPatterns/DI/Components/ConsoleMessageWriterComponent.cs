using DPatterns.DI.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.DI.Components
{
    public class ConsoleMessageWriterComponent : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
