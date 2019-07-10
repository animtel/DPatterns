using System.Collections.Generic;

namespace DPatterns.Patterns.BehavioralPatterns.Observer
{
    public class ObserverClient : IClient
    {
        public ObserverClient()
        {
            Execute();
        }
        public void Execute()
        {
            var concreteObservable = new ConcreteObservable();
            concreteObservable.AddObserver(new ConcreteObserver("Hey"));
            concreteObservable.AddObserver(new ConcreteObserver("I"));
            concreteObservable.AddObserver(new ConcreteObserver("'m"));
            concreteObservable.AddObserver(new ConcreteObserver("working"));

            concreteObservable.NotifyObservers();
        }
    }

    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    class ConcreteObservable : IObservable
    {
        private List<IObserver> observers;
        public ConcreteObservable()
        {
            observers = new List<IObserver>();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }
    
        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }
    
        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                observer.Update();
        }
    }
 
    interface IObserver
    {
        void Update();
    }
    class ConcreteObserver :IObserver
    {
        private string message;
        public ConcreteObserver(string message)
        {
            this.message = message;
        }
        public void Update()
        {
            System.Console.WriteLine($"Making smthing..... Says: {message}");
        }
    }
}