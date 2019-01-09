using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.AbstractFactory
{
    public class Customer
    {
        private IWoodProduct _woodProduct;
        private IPanelProduct _panelProduct;

        public Customer(ProductsFactory factory)
        {
            _panelProduct = factory.CreatePanelProduct();
            _woodProduct = factory.CreateWoodProduct();
        }

        public void GetNamesOfProducts()
        {
            _panelProduct.GetName();
            _woodProduct.GetName();
        }
    }
}
