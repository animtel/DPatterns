using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.FactoryMethod.Models
{
    public abstract class Developer
    {
        public string Name { get; set; }
        public Developer(string name)
        {
            Name = name;
        }

        abstract public House Create();
    }
}
