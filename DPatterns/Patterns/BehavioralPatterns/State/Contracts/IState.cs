using DPatterns.Patterns.BehavioralPatterns.State.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.BehavioralPatterns.State.Contracts
{
    public interface IState
    {
        string Handle(Context context);
    }
}
