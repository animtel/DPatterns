using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.FactoryMethod.Models
{
    public class WoodHouse: House
    {
        public WoodHouse()
        {
            Console.WriteLine("Wood house hase been created!");
        }
    }
}
