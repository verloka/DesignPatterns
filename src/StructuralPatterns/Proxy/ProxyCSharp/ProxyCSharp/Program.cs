using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCSharp
{
    //Интерфейс обьекта
    interface IMath
    {
        int Sum(int a, int b);
    }

    //Сам обьект
    class Math : IMath
    {
        public int Sum(int a, int b) => a + b;
    }

    //Заместитель обьекта
    class ProxyMath : IMath
    {
        IMath math;

        //Долгая операция, треует создания замещаемого обьекта
        public int Sum(int a, int b)
        {
            if (math == null)
                math = new Math();

            return math.Sum(a, b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Flyweight";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine((new ProxyMath()).Sum(15, 14));

            Console.Read();
        }
    }
}
