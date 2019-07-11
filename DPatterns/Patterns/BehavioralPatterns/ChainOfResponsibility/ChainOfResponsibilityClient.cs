using System;

namespace DPatterns.Patterns.BehavioralPatterns.ChainOfResponsibility
{
    public class ChainOfResponsibilityClient : IClient
    {
        public ChainOfResponsibilityClient()
        {
            Execute();
        }

        public void Execute()
        {
            var goblin = new Creature("Goblin", 2, 2);
            System.Console.WriteLine(goblin);

            var root = new CreatureModifier(goblin);
            System.Console.WriteLine("Let's double the goblin's attack");
            root.Add(new DoubleAttackModifier(goblin));

            root.Handle();

            System.Console.WriteLine(goblin);
        }
    }

    public class Creature
    {
        public string Name;
        public int Attack, Defense;

        public Creature(string name, int attack, int defense)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public class CreatureModifier
    {
        protected Creature creature;
        protected CreatureModifier next;

        public CreatureModifier(Creature creature)
        {
            this.creature = creature ?? throw new ArgumentNullException(nameof(creature));
        }

        public void Add(CreatureModifier cm)
        {
            if (next != null) next.Add(cm);
            else next = cm;
        }

        public virtual void Handle() => next?.Handle();
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            System.Console.WriteLine($"Doubling {creature.Name}'s attack.");
            creature.Attack *= 2;
            base.Handle();
        }
    }
}