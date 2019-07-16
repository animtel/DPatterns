using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.SOLID._2.OCP
{
    class OCPBadPracticeClient:IClient
    {
        public OCPBadPracticeClient()
        {
            Execute();
        }
        public void Execute()
        {
            var products = new List<Product>()
            {
                new Product("1 product", Color.Blue, Size.Large),
                new Product("2 product", Color.Green, Size.Medium),
                new Product("3 product", Color.Blue, Size.Medium),
                new Product("4 product", Color.Red, Size.Medium),
                new Product("5 product", Color.Green, Size.Small),
                new Product("6 product", Color.Blue, Size.Large),
                new Product("7 product", Color.Red, Size.Medium),
                new Product("8 product", Color.Blue, Size.Small)
            };

            var productFilter = new ProductFilter();
            var blueProducts = productFilter.FilterByColor(products, Color.Blue);
            foreach (var blueProduct in blueProducts)
            {
                Console.WriteLine(blueProduct);
            }
        }

        enum Color
        {
            Red, Green, Blue
        }

        enum Size
        {
            Small, Medium, Large
        }

        class Product
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

        class ProductFilter
        {
            //What we want, from this scenario, is to enforce the open-closed
            //principle that states that a type is open for extension, but closed for
            //modification.In other words, we want filtering that is extensible (perhaps
            //in a different assembly) without having to modify it (and recompiling
            //something that already works and might have been shipped to clients).
            //How can we achieve it? Well, first of all, we conceptually separate
            //(SRP!) our filtering process into two parts: a filter(a construct that takes all
            //items and only returns some) and a specification(a predicate to apply to a
            //data element).

            //So let's remake it in the good practice approach!

            public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
            {
                foreach (var product in products)
                {
                    if (product.Color == color)
                        yield return product;
                }
            }
            public IEnumerable<Product> FilterBySize
                (IEnumerable<Product> products, Size size)
            {
                foreach (var p in products)
                    if (p.Size == size)
                        yield return p;
            }

            public IEnumerable<Product> FilterBySizeAndColor(
                IEnumerable<Product> products,
                Size size, Color color)
            {
                foreach (var p in products)
                    if (p.Size == size && p.Color == color)
                        yield return p;
            }
        }
    }
}
