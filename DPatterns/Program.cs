using DPatterns.DI;
using DPatterns.Patterns.BehavioralPatterns.State.Contracts;
using DPatterns.Patterns.BehavioralPatterns.State.Models;
using DPatterns.Patterns.BehavioralPatterns.Strategy;
using DPatterns.Patterns.CreationalPatterns.AbstractFactory;
using DPatterns.Patterns.CreationalPatterns.FactoryMethod.Models;
using DPatterns.Patterns.CreationalPatterns.Singleton;
using DPatterns.Patterns.StructuralPatterns.Composite;
using DPatterns.Patterns.StructuralPatterns.Decorator;
using System;

namespace DPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DI
            //var di = new DIClient();
            #endregion

            #region CreationalPatternsExample
            //FactoryMethodExample();
            //AbstractFactoryExample();
            //SingletonExample();
            #endregion

            #region BehavioralPatternsExample
            //StateExample();
            var strategy = new StrategyClient();
            #endregion

            #region StructuralPatterns
            //var compositeClient = new CompositeClient();
            //var decoratorClient = new DecoratorClient();
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

        static void SingletonExample()
        {
            Singleton obj1 = Singleton.GetInstance();
            Singleton obj2 = Singleton.GetInstance();
            Singleton obj3 = Singleton.GetInstance();

            Console.WriteLine(obj1.Name);
            Console.WriteLine(obj2.Name);
            Console.WriteLine(obj3.Name);
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
