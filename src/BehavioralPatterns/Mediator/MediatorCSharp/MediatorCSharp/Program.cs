using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorCSharp
{
    //Интерфейс медиатора
    interface IMediator
    {
        void Send(string msg, IColleague coll);
    }

    //Интерфейс обькта между которыми будет происходить общение
    interface IColleague
    {
        IMediator med { get; set; }

        void SetMediator(IMediator med);
    }

    //Конкретный обект общения
    class ColleagueJack : IColleague
    {
        public IMediator med { get; set; }

        public void SetMediator(IMediator med) => this.med = med;

        public void Send(string msg) => med.Send(msg, this);
        public void Notify(string msg) => Console.WriteLine($"Jack gets message: '{msg}'");
    }

    //Конкретный обект общения
    class ColleagueJhon : IColleague
    {
        public IMediator med { get; set; }

        public void SetMediator(IMediator med) => this.med = med;

        public void Send(string msg) => med.Send(msg, this);
        public void Notify(string msg) => Console.WriteLine($"Jhon gets message: '{msg}'");
    }

    //Реализация конкретного посредника в общении между двумя обьектами
    class MediatorJackJson : IMediator
    {
        public ColleagueJack Jack { get; set; }
        public ColleagueJhon Jhon { get; set; }

        public void Send(string msg, IColleague coll)
        {
            if (coll == Jack)
                Jhon.Notify(msg);
            else if (coll == Jhon)
                Jack.Notify(msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mediator";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            MediatorJackJson mjj = new MediatorJackJson();

            ColleagueJack jack = new ColleagueJack()
            {
                med = mjj
            };
            ColleagueJhon jhon = new ColleagueJhon()
            {
                med = mjj
            };

            mjj.Jack = jack;
            mjj.Jhon = jhon;

            jack.Send("Hello, what's up?");
            jhon.Send("Hi, im fine, and you?");

            Console.Read();
        }
    }
}
