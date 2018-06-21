using System;
using System.Collections.Generic;

namespace BuilderCSharp
{
    //Класс, базовый для данного продукта
    class Pizza
    {
        string dough;
        string sause;
        string topping;

        public void SetDough(string d) => dough = d;
        public void SetSause(string s) => sause = s;
        public void SetTopping(string t) => topping = t;

        public void DecribePizza()
        {
            Console.WriteLine("Pizza!");
            Console.WriteLine($"With dough as {dough}, ");
            Console.WriteLine($"Sause as {sause} ");
            Console.WriteLine($"and Topping as {topping}.");
        }
    }

    //Абстрактный билдер для любого продукта
    abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public Pizza GetPizza() => pizza;
        public void CreateNewPizza() => pizza = new Pizza();

        public abstract void BuildDough();
        public abstract void BuildSause();
        public abstract void BuildTopping();
    }

    //Класс конкретного продукта
    class HawaiianPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough() => pizza.SetDough("cross");
        public override void BuildSause() => pizza.SetSause("hot");
        public override void BuildTopping() => pizza.SetTopping("pepperoni and salami");
    }

    //Класс конкретного продукта
    class SpicyPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough() => pizza.SetDough("pan baked");
        public override void BuildSause() => pizza.SetSause("mild");
        public override void BuildTopping() => pizza.SetTopping("ham and pineapple");
    }

    //Руководитель создания продуктов
    class Director
    {
        PizzaBuilder builder;

        public void SetPizzaBuilder(PizzaBuilder b) => builder = b;
        public Pizza GetPizza() => builder.GetPizza();
        public void CreatePizza()
        {
            builder.CreateNewPizza();

            builder.BuildDough();
            builder.BuildSause();
            builder.BuildTopping();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Builder";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Director director = new Director();
            List<Pizza> pizzas = new List<Pizza>();

            //Билдеры конкретных продуктов
            HawaiianPizzaBuilder hawaiian = new HawaiianPizzaBuilder();
            SpicyPizzaBuilder spicy = new SpicyPizzaBuilder();

            //создаем конкертный продукт
            director.SetPizzaBuilder(hawaiian);
            director.CreatePizza();
            pizzas.Add(director.GetPizza());

            //создаем конкертный продукт
            director.SetPizzaBuilder(spicy);
            director.CreatePizza();
            pizzas.Add(director.GetPizza());

            foreach (var item in pizzas)
                item.DecribePizza();

            Console.Read();
        }
    }
}
