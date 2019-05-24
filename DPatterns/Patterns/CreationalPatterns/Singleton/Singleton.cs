using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.Singleton
{
    public class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public string Name { get; private set; }
        private Singleton() => Name = Guid.NewGuid().ToString();
        public static Singleton GetInstance() => lazy.Value;
    }
}
