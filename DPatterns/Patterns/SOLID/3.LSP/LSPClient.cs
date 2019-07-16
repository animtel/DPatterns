using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.SOLID._3.LSP
{
    class LSPClient:IClient
    {
        public LSPClient()
        {
            Execute();
        }
        public void Execute()
        {
            int Area(Rectangle r) => r.Width * r.Height;

            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            Square sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");
        }

        public class Rectangle
        {
            public virtual int Height { get; set; }
            public virtual int Width { get; set; }

            public Rectangle()
            {
                
            }

            public Rectangle(int height, int width)
            {
                Height = height;
                Width = width;
            }

            public override string ToString()
            {
                return $"{nameof(Height)}: {Height}, {nameof(Width)}: {Width}";
            }
        }

        public class Square: Rectangle
        {
            public override int Width
            {
                set { base.Width = base.Height = value; }
            }

            public override int Height
            {
                set { base.Height = base.Width = value; }
            }
        }

    }
}
