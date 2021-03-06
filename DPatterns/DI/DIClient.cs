﻿using DPatterns.DI.Components;
using DPatterns.DI.Contracts;

namespace DPatterns.DI
{
    public class DIClient : IClient
    {
        public DIClient()
        {
            Execute();
        }
        public void Execute()
        {
            IMessageWriter writer = new ConsoleMessageWriterComponent();
            SalutationComponent salutation = new SalutationComponent(writer);
            salutation.Exclaim("Hello DI!");
        }
    }

}
