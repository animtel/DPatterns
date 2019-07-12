using System;

namespace DPatterns.Patterns.BehavioralPatterns.ChainOfResponsibility
{
    public class ChainOfResponsibilityClientV2 : IClient
    {
        public ChainOfResponsibilityClientV2()
        {
            Execute();
        }

        public void Execute()
        {
            var game = new GameV2();
            var goblin = new CreatureV2(game, "Strong Goblin", 3,3);
            Console.WriteLine(goblin);

            using (new DoubleAttackModifierV2(game, goblin))
            {
                Console.WriteLine(goblin);
                using (new IncreaseDoubleModifierV2(game, goblin))
                {
                    Console.WriteLine(goblin);
                }
            }

            Console.WriteLine(goblin);
        }
    }

    public class GameV2
    {
        public event EventHandler<QueryV2> Queries;

        public void PerfomQuery(object sender, QueryV2 q)
        {
            Queries?.Invoke(sender, q);
        }
    }

    public class QueryV2
    {
        public string CreatureName;

        public enum Argument
        {
            Attack, Defense
        }

        public Argument WhatToQuery;
        public int Value;

        public QueryV2(string creatureName, Argument whatToQuery, int value)
        {
            CreatureName = creatureName ?? throw new ArgumentNullException();
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }

    public class CreatureV2
    {
        private GameV2 game;
        public string Name;
        private int attack, defense;

        public CreatureV2(GameV2 game, string name, int attack, int defense)
        {
            this.game = game;
            Name = name;
            this.attack = attack;
            this.defense = defense;
        }

        public int Attack
        {
            get
            {
                var q = new QueryV2(Name, QueryV2.Argument.Attack, attack);
                game.PerfomQuery(this, q);
                return q.Value;
            }
        }

        public int Devense
        {
            get
            {
                var q = new QueryV2(Name, QueryV2.Argument.Defense, attack);
                game.PerfomQuery(this, q);
                return q.Value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Devense)}: {Devense}";
        }
    }

    public abstract class CreatureModifierV2:IDisposable
    {
        protected GameV2 game;
        protected CreatureV2 creature;

        protected CreatureModifierV2(GameV2 game, CreatureV2 creature)
        {
            this.game = game;
            this.creature = creature;
            game.Queries += Handle;
        }

        protected abstract void Handle(object sender, QueryV2 query);

        public void Dispose()
        {
            game.Queries -= Handle;
        }
    }

    public class DoubleAttackModifierV2 : CreatureModifierV2
    {
        public DoubleAttackModifierV2(GameV2 game, CreatureV2 creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, QueryV2 query)
        {
            if (query.CreatureName == creature.Name
                && query.WhatToQuery == QueryV2.Argument.Attack)
            {
                query.Value *= 2;
            }
        }
    }

    public class IncreaseDoubleModifierV2 : CreatureModifierV2
    {
        public IncreaseDoubleModifierV2(GameV2 game, CreatureV2 creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, QueryV2 query)
        {
            if (query.CreatureName == creature.Name
                && query.WhatToQuery == QueryV2.Argument.Defense)
            {
                query.Value *= 2;
            }
        }
    }
}