using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.AbstractFactory
{
    public class PanelFactory : ProductsFactory
    {
        public PanelFactory()
        {

        }
        public override IPanelProduct CreatePanelProduct()
        {
            return new PanelProduct("Panel Product 1");
        }

        public override IWoodProduct CreateWoodProduct()
        {
            return new WoodProduct("Wood Product 1");
        }
    }
}
