using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterCSharp
{
    //Контекст который будет интерпретироватся
    class Context
    {
        public string Input { get; set; }
        public int Output { get; set; }

        public Context(string input = "")
        {
            Input = input;
        }
    }

    //абстрактный класс для римских цифр
    abstract class RomanNumner
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Four()))
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five()))
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(1);
            }

            while (context.Input.StartsWith(One()))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    //конкретные реализации
    class ThousandNumner : RomanNumner
    {
        public override string One() { return "M"; }
        public override string Four() { return " "; }
        public override string Five() { return " "; }
        public override string Nine() { return " "; }
        public override int Multiplier() { return 1000; }
    }

    class HundredNumner : RomanNumner

    {
        public override string One() { return "C"; }
        public override string Four() { return "CD"; }
        public override string Five() { return "D"; }
        public override string Nine() { return "CM"; }
        public override int Multiplier() { return 100; }
    }

    class TenNumner : RomanNumner

    {
        public override string One() { return "X"; }
        public override string Four() { return "XL"; }
        public override string Five() { return "L"; }
        public override string Nine() { return "XC"; }
        public override int Multiplier() { return 10; }
    }

    class OneNumner : RomanNumner

    {
        public override string One() { return "I"; }
        public override string Four() { return "IV"; }
        public override string Five() { return "V"; }
        public override string Nine() { return "IX"; }
        public override int Multiplier() { return 1; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Interpreter";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            List<RomanNumner> interpreters = new List<RomanNumner>()
            {
                new ThousandNumner(),
                new HundredNumner(),
                new TenNumner(),
                new OneNumner()
            };

            Console.WriteLine("e. Выход");
            Console.Write("Введите римское число: ");

            string input = "";

            while ((input = Console.ReadLine()) != "e")
            {
                Context ctx = new Context(input);

                foreach (RomanNumner inr in interpreters)
                    inr.Interpret(ctx);

                Console.WriteLine($"Римское число {input} в арабском представлении: {ctx.Output}");
                Console.Write("Введите римское число: ");
            }
        }
    }
}
