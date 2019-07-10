using System;
using DPatterns.Patterns.BehavioralPatterns.Strategy.Contracts;

namespace DPatterns.Patterns.BehavioralPatterns.Strategy
{
    public class StrategyClient: IClient
    {
        public StrategyClient()
        {
            this.Execute();
        }

        public void Execute()
        {
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();
    
            Console.ReadLine();
        }
    }
}