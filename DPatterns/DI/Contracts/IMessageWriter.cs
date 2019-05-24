using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.DI.Contracts
{
    public interface IMessageWriter
    {
        void Write(string message);
    }
}
