using DPatterns.Patterns.CreationalPatterns.AbstractFactory;
using DPatterns.Patterns.CreationalPatterns.FactoryMethod.Models;
using System;

namespace DPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region CreationalPatternsExample
            //FactoryMethodExample();
            AbstractFactoryExample();
            #endregion
        }


        #region CreationalPatternsExampleMethods
        static void FactoryMethodExample()
        {
            Developer dev = new PanelDeveloper("PanelDeveloper Nick");
            House panelHouse = dev.Create();

            dev = new WoodDeveloper("WoodDeveloper John");
            House woodHouse = dev.Create();

            Console.ReadKey();
        }

        static void AbstractFactoryExample()
        {
            Customer customer = new Customer(new PanelFactory());
            customer.GetNamesOfProducts();

            customer = new Customer(new WoodFactory());
            customer.GetNamesOfProducts();

            Console.ReadKey();
        }
        #endregion
    }
}
