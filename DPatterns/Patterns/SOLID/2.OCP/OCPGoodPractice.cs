using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.SOLID._2.OCP
{
    class OCPGoodPracticeClient:IClient
    {
        public OCPGoodPracticeClient()
        {
            Execute();
        }
        public void Execute()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);
            Product[] products = { apple, tree, house };
            var pf = new BetterFilter();
            Console.WriteLine("Green products:");
            foreach (var p in pf.Filter(products, new ColorSpecification(Color.Green)))
                Console.WriteLine(p);
        }

        public enum Color
        {
            Red, Green, Blue
        }

        public enum Size
        {
            Small, Medium, Large
        }

        public class Product
        {
            public string Name;
            public Color Color;
            public Size Size;

            public Product(string name, Color color, Size size)
            {
                Name = name;
                Color = color;
                Size = size;
            }

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Color)}: {Color}, {nameof(Size)}: {Size}";
            }
        }

        public interface ISpecification<T>
        {
            bool IsSatisfied(T item);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        }

        public class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items,
                ISpecification<Product> spec)
            {
                foreach (var i in items)
                    if (spec.IsSatisfied(i))
                        yield return i;
            }
        }

        public class ColorSpecification : ISpecification<Product>
        {
            private Color color;
            public ColorSpecification(Color color)
            {
                this.color = color;
            }
            public bool IsSatisfied(Product p)
            {
                return p.Color == color;
            }
        }
    }
}
