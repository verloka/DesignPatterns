using System;

namespace PrototypeCSharp
{
    //Базовый клас прототипа
    abstract class Meal
    {
        public abstract void Eat();
        public abstract Meal Clone();
    }

    //Конкретный класс прототипа
    class Spaghetti : Meal
    {
        public override Meal Clone() => (Meal)MemberwiseClone();
        public override void Eat() => Console.WriteLine("Eat a peace of Spaghetti");
    }

    //Конкретный класс прототипа
    class Meat : Meal
    {
        public override Meal Clone() => (Meal)MemberwiseClone();
        public override void Eat() => Console.WriteLine("Eat a peace of Meat");
    }

    //Фабрика по производству обьектов с прототипа
    class Factory
    {
        Meal[] meals = new Meal[]{ new Meat(), new Spaghetti()};

        //Создаем новые обьекты путем клонирования существующих уже "давно"
        public Meal CreateMeale(int n) => meals[n].Clone();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Prototype";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Factory factory = new Factory();

            Meal meat = factory.CreateMeale(0);
            Meal spaghetti = factory.CreateMeale(1);

            meat.Eat();
            spaghetti.Eat();

            Console.Read();
        }
    }
}
