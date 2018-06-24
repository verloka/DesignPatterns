using System;

namespace SingletonCSharp
{
    public class Singleton
    {
        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());

        public int I { get; set; }

        private Singleton() { I = 0; }

        public static Singleton Instance { get => instance.Value; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Singleton";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine($"Singleton befor change: {Singleton.Instance.I}");

            Singleton.Instance.I = 99;

            Console.WriteLine($"Singleton after change: {Singleton.Instance.I}");

            Console.Read();
        }
    }
}
