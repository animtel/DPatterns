﻿using DPatterns.DI;
using DPatterns.Patterns.BehavioralPatterns.ChainOfResponsibility;
using DPatterns.Patterns.BehavioralPatterns.Command;
using DPatterns.Patterns.BehavioralPatterns.Observer;
using DPatterns.Patterns.BehavioralPatterns.State.Contracts;
using DPatterns.Patterns.BehavioralPatterns.State.Models;
using DPatterns.Patterns.BehavioralPatterns.Strategy;
using DPatterns.Patterns.BehavioralPatterns.TemplateMethod;
using DPatterns.Patterns.CreationalPatterns.AbstractFactory;
using DPatterns.Patterns.CreationalPatterns.FactoryMethod.Models;
using DPatterns.Patterns.CreationalPatterns.Singleton;
using DPatterns.Patterns.StructuralPatterns.Composite;
using DPatterns.Patterns.StructuralPatterns.Decorator;
using System;
using DPatterns.Patterns.BehavioralPatterns.Interpreter;
using DPatterns.Patterns.CreationalPatterns.Builder;
using DPatterns.Patterns.CreationalPatterns.Prototype;

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
            var builderClient = new BuilderClient();

            #endregion

            #region BehavioralPatternsExample

            //StateExample();
            //var strategy = new StrategyClient();
            //var strategyv2 = new StrategyClientV2();
            //var observer = new ObserverClient();
            //var command = new CommandClient();
            //var commandv2 = new CommandClientV2();
            //var templateMethod = new TemplateMethodClient();
            //var chainOfResponsibilityClient = new ChainOfResponsibilityClient();
            //var chainOfResponsibilityClientV2 = new ChainOfResponsibilityClientV2();
            //var interpreterClient = new InterpreterClient();
            //var prototypeClient = new PrototypeClient();

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
