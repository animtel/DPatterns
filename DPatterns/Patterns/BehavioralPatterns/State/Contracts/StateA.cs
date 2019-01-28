using System;
using System.Collections.Generic;
using System.Text;
using DPatterns.Patterns.BehavioralPatterns.State.Models;

namespace DPatterns.Patterns.BehavioralPatterns.State.Contracts
{
    public class StateA : IState
    {
        public string Handle(Context context)
        {
            context.State = new StateB();
            return "State have changed to StateB";
        }
    }
}
