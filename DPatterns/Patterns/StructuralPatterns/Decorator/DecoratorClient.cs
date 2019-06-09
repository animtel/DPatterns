using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.StructuralPatterns.Decorator
{
    public class DecoratorClient : IClient
    {
        public DecoratorClient()
        {
            Execute();
        }

        public void Execute()
        {
            var loggers = new List<ITLogger>
            {
                new Logger(),
                new TelegramDecorator(new Logger()),
                new ViberDecorator(new TelegramDecorator(new Logger()))
            };

            foreach (var logger in loggers)
            {
                Console.WriteLine("**************************************************************************");
                Console.WriteLine("Description");
                Console.WriteLine(logger.GetDescription());
                Console.WriteLine("Log");
                Console.WriteLine(logger.Log());
                Console.WriteLine("**************************************************************************");
            }
        }
    }

    public interface ITLogger
    {
        string GetDescription();
        string Log();
    }

    public class Logger : ITLogger
    {
        public string GetDescription()
        {
            return "Base Logger in the system";
        }

        public string Log()
        {
            return "Log to file";
        }
    }

    public abstract class BaseTypeLoggerDecorator : ITLogger
    {
        ITLogger _logger;

        protected string _name = "undefined condiment";
        protected string _message = "";

        public BaseTypeLoggerDecorator(ITLogger logger)
        {
            _logger = logger;
        }

        public string GetDescription()
        {
            return string.Format("{0}, {1}", _logger.GetDescription(), _name);
        }

        public string Log()
        {
            return _logger.Log() + _message;
        }
    }

    public class TelegramDecorator : BaseTypeLoggerDecorator
    {
        public TelegramDecorator(ITLogger logger)
            : base(logger)
        {
            _name = "Telegram";
            _message = "Log to telegram";
        }
    }

    public class ViberDecorator : BaseTypeLoggerDecorator
    {
        public ViberDecorator(ITLogger logger)
            : base(logger)
        {
            _name = "Viber";
            _message = "Log to viber";
        }
    }
}
