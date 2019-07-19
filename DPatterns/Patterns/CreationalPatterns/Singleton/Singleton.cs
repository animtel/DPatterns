using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DPatterns.Patterns.CreationalPatterns.Singleton
{
    //A singleton it's just component which need to be created once and have only one instance in full lifecycle of app.
    class SingletonClient : IClient
    {
        public SingletonClient()
        {
            Execute();
        }
        public void Execute()
        {
            var singletonExample = Singleton.GetInstance();
            var singletonExample2 = Singleton.GetInstance();
            if (singletonExample.Name == singletonExample2.Name)
            {
                Console.WriteLine("Singleton had created once");
            }
        }
    }

    public class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public string Name { get; private set; }
        private Singleton() => Name = Guid.NewGuid().ToString();
        public static Singleton GetInstance() => lazy.Value;
    }
}
