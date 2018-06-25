using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeCSharp
{
    //Интерфейс
    interface IPizzaCreator
    {
        void CreateBase();
        void CreateTopping();
    }

    //Реализация
    class PizzaWithChicken : IPizzaCreator
    {
        public void CreateBase()
        {
            Console.WriteLine("Simple base created");
        }
        public void CreateTopping()
        {
            Console.WriteLine("Add a piece of chicken");
        }
    }

    //Реализация
    class PizzaWithPinApple : IPizzaCreator
    {
        public void CreateBase()
        {
            Console.WriteLine("Lux base created!");
        }

        public void CreateTopping()
        {
            Console.WriteLine("Add a piece of golden pinapple from Amazonia");
        }
    }

    //Абстрактный класс
    abstract class IOffer
    {
        //Мост
        protected IPizzaCreator pc;

        public void SetCreator(IPizzaCreator pc) => this.pc = pc;
        public abstract void CreateBase();
        public abstract void CreatePizza();
    }

    //Реализация конкретного предложения
    class OfferPooor : IOffer
    {
        public override void CreateBase() { pc.CreateBase();  }
        public override void CreatePizza()
        {
            pc.CreateTopping();
            pc.CreateTopping();
            Console.WriteLine("Poor pizza created!");
        }
    }

    //Реализация конкретного предложения
    class OfferRich : IOffer
    {
        public override void CreateBase() { pc.CreateBase(); }

        public override void CreatePizza()
        {
            pc.CreateTopping();
            pc.CreateTopping();
            pc.CreateTopping();
            pc.CreateTopping();
            pc.CreateTopping();
            Console.WriteLine("Rich pizza created!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Bridg";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            PizzaWithChicken chicken = new PizzaWithChicken();
            PizzaWithPinApple pinApple = new PizzaWithPinApple();

            OfferPooor pooor = new OfferPooor();
            OfferRich rich = new OfferRich();

            Console.WriteLine("Create poor pizza with simple products:");
            pooor.SetCreator(chicken);
            pooor.CreateBase();
            pooor.CreatePizza();

            Console.WriteLine("\nCreate poor pizza with lux products:");
            pooor.SetCreator(pinApple);
            pooor.CreateBase();
            pooor.CreatePizza();

            Console.WriteLine("\nCreate rich pizza with simple products:");
            rich.SetCreator(chicken);
            rich.CreateBase();
            rich.CreatePizza();

            Console.WriteLine("\nCreate rich pizza with lux products:");
            rich.SetCreator(pinApple);
            rich.CreateBase();
            rich.CreatePizza();

            Console.Read();
        }
    }
}
