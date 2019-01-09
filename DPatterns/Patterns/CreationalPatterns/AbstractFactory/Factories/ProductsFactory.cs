using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.AbstractFactory
{
    public abstract class ProductsFactory
    {
        public abstract IWoodProduct CreateWoodProduct();
        public abstract IPanelProduct CreatePanelProduct();
    }
}
