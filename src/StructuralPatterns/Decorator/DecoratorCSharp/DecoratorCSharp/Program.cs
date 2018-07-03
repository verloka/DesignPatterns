using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorCSharp
{
    //Интерфейс расширяемого обьекта
    interface IComponent
    {
        void Action();
    }

    //Объект который необходимо расиширить
    class Component : IComponent
    {
        public void Action()
        {
            Console.Write("World!\n");
        }
    }

    //Первое расширение
    class DecoratorOne : IComponent
    {
        IComponent comp;

        public DecoratorOne(IComponent component) { comp = component; }

        public void Action()
        {
            Console.Write(", ");
            comp.Action();
        }
    }

    //Второе расширение
    class DecoratorTwo : IComponent
    {
        IComponent comp;

        public DecoratorTwo(IComponent component) { comp = component; }

        public void Action()
        {
            Console.Write("Hello");
            comp.Action();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Decorator";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            (new DecoratorTwo(new DecoratorOne(new Component()))).Action();

            Console.Read();
        }
    }
}
