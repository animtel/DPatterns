using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.StructuralPatterns.Decorator.Logic
{
    public abstract class LoggerDecorator: Logger
    {
        protected Logger _logger;
        public LoggerDecorator(string message, Logger logger): base(message)
        {
            _logger = logger;
        }
    }
}
