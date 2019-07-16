using System;
using System.Collections.Generic;
using System.Linq;

namespace DPatterns.Patterns.BehavioralPatterns.Command
{
    public class CommandClientV2 : IClient
    {
        public CommandClientV2()
        {
            Execute();
        }

        public void Execute()
        {
            var ba = new BankAccount();
            var commands = new List<BankAccountCommand>
            {
                new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 50)
            };

            System.Console.WriteLine(ba);

            foreach (var c in commands)
                c.Call();

            System.Console.WriteLine(ba);

            foreach (var c in Enumerable.Reverse(commands))
                c.Undo();

            System.Console.WriteLine(ba);
        }
    }

    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            System.Console.WriteLine($"Deposited ${amount}, balance is now {balance}");
        }

        public bool Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                System.Console.WriteLine($"Withdrew ${amount}, balance is now {balance}");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public interface ICommandV2
    {
        void Call();
        void Undo();
    }

    public class BankAccountCommand : ICommandV2
    {
        private BankAccount account { get; set; }
        private Action action { get; set; }
        private int amount { get; set; }
        private bool succeeded;

        public enum Action
        {
            Deposit,
            Withdraw
        }

        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            this.amount = amount;
            this.action = action;
            this.account = account ?? throw new ArgumentNullException(nameof(account));
        }

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    account.Deposit(amount);
                    succeeded = true;
                    break;
                case Action.Withdraw:
                    succeeded = account.Withdraw(amount);
                    break;
            }
        }

        public void Undo()
        {
            if (!succeeded)
                return;

            switch (action)
            {
                case Action.Deposit:
                    account.Withdraw(amount);
                    break;
                case Action.Withdraw:
                    account.Deposit(amount);
                    break;
            }
        }
    }
}