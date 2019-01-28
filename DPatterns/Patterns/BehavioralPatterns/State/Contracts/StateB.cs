using System;
using System.Collections.Generic;
using System.Text;
using DPatterns.Patterns.BehavioralPatterns.State.Models;

namespace DPatterns.Patterns.BehavioralPatterns.State.Contracts
{
    public class StateB : IState
    {
        public string Handle(Context context)
        {
            context.State = new StateA();
            return "State have changed to StateA";
        }
    }
}
