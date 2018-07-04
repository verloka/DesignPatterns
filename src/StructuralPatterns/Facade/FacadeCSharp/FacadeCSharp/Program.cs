using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeCSharp
{
    //Первая подсистема
    class Welcome
    {
        public Welcome() { }

        public void DrawStart() => Console.WriteLine("#  << Start    #");
        public void DrawResume() => Console.WriteLine("#  << Resume   #");
        public void DrawLoad() => Console.WriteLine("#  << Load     #");
        public void DrawSave() => Console.WriteLine("#  << Save     #");
        public void DrawOptions() => Console.WriteLine("#  << Options  #");
        public void DrawExit() => Console.WriteLine("#  << Exit     #");
        public void DrawBack() => Console.WriteLine("#  << Back     #");
    };

    //Вторая подсистема, может быть большое количество
    class Decoration
    {
        public Decoration() { }

        public void DrawEmptyLine() => Console.WriteLine("#              #");
        public void DrawWallLine() => Console.WriteLine("################");
    };

    //Непосредственно фасад
    class Menu
    {
        Welcome w;
        Decoration d;

        public Menu()
        {
            w = new Welcome();
            d = new Decoration();
        }

        public void DrawStartMenu()
        {
            d.DrawWallLine();
            d.DrawEmptyLine();
            Console.WriteLine("#   Start      #");
            d.DrawEmptyLine();

            w.DrawStart();
            w.DrawLoad();
            w.DrawOptions();
            w.DrawExit();

            d.DrawEmptyLine();
            d.DrawWallLine();
        }
        public void DrawInGameMenu()
        {
            d.DrawWallLine();
            d.DrawEmptyLine();
            Console.WriteLine("#   In Game    #");
            d.DrawEmptyLine();

            w.DrawResume();
            w.DrawSave();
            w.DrawLoad();
            w.DrawOptions();
            w.DrawBack();

            d.DrawEmptyLine();
            d.DrawWallLine();
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Facade";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Menu m = new Menu();

            m.DrawStartMenu();

            Console.WriteLine("\n\n\n");

            m.DrawInGameMenu();

            Console.Read();
        }
    }
}
