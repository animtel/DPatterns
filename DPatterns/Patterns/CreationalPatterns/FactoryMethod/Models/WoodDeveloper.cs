using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.FactoryMethod.Models
{
    public class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name): base(name)
        {

        }

        public override House Create()
        {
            return new WoodHouse();
        }
    }
}
