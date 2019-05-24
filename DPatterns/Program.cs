using DPatterns.DI;
using DPatterns.Patterns.BehavioralPatterns.State.Contracts;
using DPatterns.Patterns.BehavioralPatterns.State.Models;
using DPatterns.Patterns.CreationalPatterns.AbstractFactory;
using DPatterns.Patterns.CreationalPatterns.FactoryMethod.Models;
using System;

namespace DPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DI
            var di = new DIClient();
            #endregion


            #region CreationalPatternsExample
            //FactoryMethodExample();
            //AbstractFactoryExample();
            #endregion

            #region BehavioralPatternsExample
            //StateExample();
            #endregion

            Console.ReadKey();
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

        #region BehavioralPatternsExampleMethods
        static void StateExample()
        {
            Context context = new Context(new StateA());
            context.ChangeState();
            context.ChangeState();
        }
        #endregion
    }
}
