using System;

namespace DPatterns.Patterns.BehavioralPatterns.Command
{
    public class CommandClient : IClient
    {
        public CommandClient()
        {
            Execute();
        }
        public void Execute()
        {
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();
        }
    }
    interface ICommand
    {
        void Execute();
        void Undo();
    }
    
    // Receiver
    class TV
    { 
        public void On()
        {
            Console.WriteLine("TV on.");
        }
    
        public void Off()
        {
            Console.WriteLine("TV off...");
        }
    }
    
    class TVOnCommand : ICommand
    {
        TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }
        public void Execute()
        {
            tv.On();
        }
        public void Undo()
        {
            tv.Off();
        }
    }
    
    // Invoker
    class Pult
    {
        ICommand command;
    
        public Pult() { }
    
        public void SetCommand(ICommand com)
        {
            command = com;
        }
    
        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }
}