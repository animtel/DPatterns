using DPatterns.DI.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.DI.Components
{
    public class SalutationComponent
    {
        private readonly IMessageWriter _writer;

        public SalutationComponent(IMessageWriter writer)
        {
            if (writer == null)
                throw new NullReferenceException("writer");

            _writer = writer;
        }

        public void Exclaim(string message)
        {
            this._writer.Write(message);
        }
    }
}
