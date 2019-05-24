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
            throw new NotImplementedException();
        }
    }
}
