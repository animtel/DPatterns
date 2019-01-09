using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.FactoryMethod.Models
{
    public class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name): base(name)
        {

        }
        public override House Create()
        {
            return new PanelHouse();
        }
    }
}
