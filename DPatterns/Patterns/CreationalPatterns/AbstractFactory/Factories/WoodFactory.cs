using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.AbstractFactory
{
    public class WoodFactory: ProductsFactory
    {
        public WoodFactory()
        {

        }
        public override IPanelProduct CreatePanelProduct()
        {
            return new PanelProduct("Panel Product 2");
        }

        public override IWoodProduct CreateWoodProduct()
        {
            return new WoodProduct("Wood Product 2");
        }
    }
}
