using DPatterns.Patterns.BehavioralPatterns.State.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.BehavioralPatterns.State.Models
{
    public class Context
    {
        public IState State { get; set; }
        public Context(IState state)
        {
            State = state;
        }
        public void ChangeState()
        {
            var resp = this.State.Handle(this);
            Console.WriteLine(resp);
        }
    }
}
