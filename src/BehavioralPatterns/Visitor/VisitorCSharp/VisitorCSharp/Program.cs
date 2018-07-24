using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorCSharp
{
    //Посетитель
    class Visitor
    {
        public void Visit(Shape s) => s.Draw();
    }

    //Обьект который будут посещать
    class Shape
    {
        public void Draw() => Console.WriteLine("Drawing a simple shape");
        public void Accept(Visitor v) => v.Visit(this);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Visitor";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Visitor v = new Visitor();
            Shape s = new Shape();

            s.Accept(v);

            Console.Read();
        }
    }
}
