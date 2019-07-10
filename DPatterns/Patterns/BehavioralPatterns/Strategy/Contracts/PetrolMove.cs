namespace DPatterns.Patterns.BehavioralPatterns.Strategy.Contracts
{
    public class PetrolMove : IMovable
    {
        public void Move()
        {
            System.Console.WriteLine("Car using petrol for moving");;
        }
    }
}