using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightCSharp
{
    //Интерфейс приспособленца
    interface IChar
    {
        char Symbol { get; set; }
        int Size { get; set; }

        void Draw();
    }

    //Конкретный приспособленец
    class MyChar : IChar
    {
        public char Symbol { get; set; }
        public int Size { get; set; }

        public MyChar(char s, int z)
        {
            Symbol = s;
            Size = z;
        }

        public void Draw() => Console.WriteLine($"{Symbol} as {Size} points");
    }

    //Фабрика приспособленцев
    class Factory
    {
        int size;
        Hashtable chars;

        public Factory(int size = 12)
        {
            this.size = size;
            chars = new Hashtable();
        }

        public MyChar GetChar(char key)
        {
            MyChar mc = chars[key] as MyChar;

            if(mc == null)
            {
                mc = new MyChar(key, size);
                chars.Add(key, mc);
            }

            return mc;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Flyweight";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            string s = "dsSSWdsd";

            Factory f = new Factory();

            foreach (var item in s)
                f.GetChar(item).Draw();

            Console.WriteLine("\n\n\n");

            Factory f2 = new Factory(24);

            foreach (var item in s)
                f2.GetChar(item).Draw();

            Console.Read();
        }
    }
}
