using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoCSharp
{
    //Класс для хранения состояния обьекта
    class Memento
    {
        internal int State { get; set; }
        public Memento(int m) { State = m; }
    }

    //Какойто оригинальный обьект, состояние которого
    //необходимо хранитть
    class RealObject
    {
        public int State { get; set; }
        public Memento Memento
        {
            get => new Memento(State);
            set => State = value.State;
        }
    }

    //Обьект, который несет ответсвенность за хранение 
    //снапшотов обьекта
    class Caretaker
    {
        public RealObject RO { get; private set; }
        List<Memento> history;

        public Caretaker(RealObject ro)
        {
            RO = ro;
            history = new List<Memento>();
        }

        public void Save()
        {
            Console.WriteLine($"State '{RO.State}' is saved!");
            history.Add(RO.Memento);
        }
        public void Undo()
        {
            RO.Memento = history.Last();
            history.Remove(history.Last());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Memento";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            RealObject ro = new RealObject();
            Caretaker cr = new Caretaker(ro);

            ro.State = 44;
            cr.Save();

            ro.State = 99;
            cr.Save();

            ro.State = 123445;

            cr.Undo();
            cr.Undo();

            Console.WriteLine($"After two undos state is '{ro.State}'");

            Console.Read();
        }
    }
}
