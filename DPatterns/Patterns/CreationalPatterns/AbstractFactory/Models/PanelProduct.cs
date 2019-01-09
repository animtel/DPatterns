using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.AbstractFactory
{
    public class PanelProduct : IPanelProduct
    {
        public PanelProduct(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void GetName()
        {
            Console.WriteLine(Name);
        }
    }
}
