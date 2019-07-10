namespace DPatterns.Patterns.BehavioralPatterns.Strategy.Contracts
{
    public class ElectricMove : IMovable
    {
        public void Move()
        {
            System.Console.WriteLine("Car using electric power for move");
        }
    }
}