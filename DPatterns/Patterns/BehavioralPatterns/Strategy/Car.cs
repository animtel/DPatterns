using DPatterns.Patterns.BehavioralPatterns.Strategy.Contracts;

namespace DPatterns.Patterns.BehavioralPatterns.Strategy
{
    public class Car
    {
        protected int passengers; 
        protected string model;
 
        public Car(int num, string model, IMovable mov)
        {
            this.passengers = num;
            this.model = model;
            Movable = mov;
        }
        public IMovable Movable { private get; set; }
        public void Move()
        {
            Movable.Move();
        }
    }
}