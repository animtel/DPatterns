using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.StructuralPatterns.Composite
{
    /// <summary>
    /// Композитор - паттерн, который объеденяет какие-либо группы объектов, связанных между собой композитором в дерево зависимостей
    /// которое позволяет работать как с целой системой полностью, так и с отдельными ее компонетами
    /// Когда использовать?
    /// Когда объекты должны быть реализованы в виде иерархической древовидной структуры.
    /// Когда клиенты единообразно должны управлять как целыми объектами, так и их составными частями. То есть целое и его части должны реализовать один и тот же интерфейс.
    /// </summary>
    public class CompositeClient : IClient
    {
        public CompositeClient()
        {
            Execute();
        }

        public void Execute()
        {
            Component root = new Composite("Root");
            Component leaf = new Leaf("Leaf");
            Composite subtree = new Composite("Subtree");
            root.Add(leaf);
            root.Add(subtree);
            root.Display();
        }

        abstract class Component // Our compositor
        {
            protected string name;

            public Component(string name)
            {
                this.name = name;
            }

            public abstract void Display();
            public abstract void Add(Component c);
            public abstract void Remove(Component c);
        }

        class Composite : Component
        {
            List<Component> children = new List<Component>();

            public Composite(string name)
                : base(name)
            { }

            public override void Add(Component component)
            {
                children.Add(component);
            }

            public override void Remove(Component component)
            {
                children.Remove(component);
            }

            public override void Display()
            {
                Console.WriteLine(name);

                foreach (Component component in children)
                {
                    component.Display();
                }
            }
        }

        class Leaf : Component
        {
            public Leaf(string name)
                : base(name)
            { }

            public override void Display()
            {
                Console.WriteLine(name);
            }

            public override void Add(Component component)
            {
                throw new NotImplementedException();
            }

            public override void Remove(Component component)
            {
                throw new NotImplementedException();
            }
        }
    }
}
