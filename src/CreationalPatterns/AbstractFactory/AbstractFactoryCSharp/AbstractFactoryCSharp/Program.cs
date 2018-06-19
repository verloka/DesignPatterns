using System;
using System.Collections.Generic;

namespace AbstractFactoryCSharp
{
    //Абстрактный класс для всех воинов
    public abstract class Warrior
    {
        public abstract void GetInfor();
    }

    //Классы воинов рима
    class RomanWarriorInfantryman : Warrior
    {
        public override void GetInfor() { Console.WriteLine("Roman Warrior Infantryman"); }
    }

    class RomanWarriorArcher : Warrior
    {
        public override void GetInfor() { Console.WriteLine("Roman Warrior Archer"); }
    }

    class RomanWarriorHorseman : Warrior
    {
        public override void GetInfor() { Console.WriteLine("Roman Warrior Horseman"); }
    }

    //Классы воинов карфагена
    class CarthaginianWarriorInfantryman : Warrior
    {
        public override void GetInfor() { Console.WriteLine("Carthaginian Warrior Infantryman"); }
    }

    class CarthaginianWarriorArcher : Warrior
    {
        public override void GetInfor() { Console.WriteLine("Carthaginian Warrior Archer"); }
    }

    class CarthaginianWarriorHorseman : Warrior
    {
        public override void GetInfor() { Console.WriteLine("Carthaginian Warrior Horseman"); }
    }

    //Абстрактный класс для фабрики по произодству воинов
    public abstract class ArmyFactory
    {
        public abstract Warrior WarriorInfantryman();
        public abstract Warrior WarriorArcher();
        public abstract Warrior WarriorHorseman();
    }

    //Фабрика для производства воинов рима
    public class RomeArmyFactory : ArmyFactory
    {
        public override Warrior WarriorArcher() => new RomanWarriorArcher();
        public override Warrior WarriorHorseman() => new RomanWarriorHorseman();
        public override Warrior WarriorInfantryman() => new RomanWarriorInfantryman();
    }

    //Фабрика для производства воинов карфагена
    public class CarthaginianArmyFactory : ArmyFactory
    {
        public override Warrior WarriorArcher() => new CarthaginianWarriorArcher();
        public override Warrior WarriorHorseman() => new CarthaginianWarriorHorseman();
        public override Warrior WarriorInfantryman() => new CarthaginianWarriorInfantryman();
    }

    //Классы для демонстрации работы шаблона Абстрактная фабрика
    //Класс для хранениния всех воинов
    public class Army
    {
        public List<Warrior> warriors { get; set; }

        public Army()
        {
            warriors = new List<Warrior>();
        }

        ///Выводим информацию об каждом воине в армии
        public void GetInfor()
        {
            foreach (var item in warriors)
            {
                item.GetInfor();
            }
        }
    }

    //Клас игры для согдания армий
    public class Game
    {
        ///Создаем армии согласно переданой фабрики
        public static Army CreateArmy(ArmyFactory fac)
        {
            Army arm = new Army();

            arm.warriors.Add(fac.WarriorArcher());
            arm.warriors.Add(fac.WarriorHorseman());
            arm.warriors.Add(fac.WarriorInfantryman());

            return arm;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Abstract factory";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            RomeArmyFactory romanFactory = new RomeArmyFactory();
            CarthaginianArmyFactory carthaginianArmyFactory = new CarthaginianArmyFactory();

            Army roman = Game.CreateArmy(romanFactory);
            Army carthaginian = Game.CreateArmy(carthaginianArmyFactory);

            Console.WriteLine("Roman army:");

            roman.GetInfor();

            Console.WriteLine("\nCarthaginian army:");

            carthaginian.GetInfor();

            Console.Read();
        }
    }
}
