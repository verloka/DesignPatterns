using System;
using System.Collections.Generic;

namespace FactoryMethodCSharp
{
    //Абстрактный класс продукта
    abstract class Drink {  public abstract string GetName(); }

    //Класс конкретного продукта
    class TeaDrink : Drink  {  public override string GetName() => "Lipton"; }

    //Класс конкретного продукта
    class CoffeDrink : Drink { public override string GetName() => "Jacobs"; }

    //Класс конкретного продукта
    class PepsiDrink : Drink { public override string GetName() => "Pepsi"; }

    //Создатель, содержит фабричный метод
    abstract class Creator { public abstract Drink FactoryMethod(); }

    //Конкретный создатель со своей реализацией фабричного метода
    class CreatorTeaDrink : Creator { public override Drink FactoryMethod() => new TeaDrink(); }

    //Конкретный создатель со своей реализацией фабричного метода
    class CreatorCoffeDrink : Creator { public override Drink FactoryMethod() => new CoffeDrink(); }

    //Конкретный создатель со своей реализацией фабричного метода
    class CreatorPepsiDrink : Creator { public override Drink FactoryMethod() => new PepsiDrink(); }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Factory Method";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            List<Creator> creators = new List<Creator>()
            {
                new CreatorTeaDrink(),
                new CreatorCoffeDrink(),
                new CreatorPepsiDrink()
            };

            foreach (var item in creators)
                Console.WriteLine(item.FactoryMethod().GetName());

            Console.Read();
        }
    }
}
