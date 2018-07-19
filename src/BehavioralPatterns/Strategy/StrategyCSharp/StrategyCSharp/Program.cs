using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyCSharp
{
    //Интерфейс стратегии
    interface IStrategy { void Use(); }

    //Конкретная стратегия
    class WorldStrategy : IStrategy { public void Use() => Console.WriteLine("Hello, World!"); }

    //Конкретная стратегия
    class MotherStrategy : IStrategy { public void Use() => Console.WriteLine("Hello, Motherland!"); }

    //Клиент, который выполняет стратегию
    class Client
    {
        public IStrategy Strategy { set; private get; } 
        public void UseStrategy() => Strategy.Use();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Strategy";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Client c = new Client();

            c.Strategy = new WorldStrategy();
            c.UseStrategy();

            c.Strategy = new MotherStrategy();
            c.UseStrategy();

            Console.Read();
        }
    }
}
