using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateCSharp
{
    //Интерфейс состояния
    interface IState { void Handle();  }

    //Конкретное состояние
    class PlayState : IState { public void Handle() => Console.WriteLine("Playing in the game!"); }

    //Конкретное состояние
    class PauseState : IState { public void Handle() => Console.WriteLine("Pause in the game!"); }

    //Объект игры, виджет
    class GameWidget
    {
        public IState State { set; private get; }
        public void Action() => State.Handle();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mediator";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            PlayState ps = new PlayState();
            PauseState ss = new PauseState();

            GameWidget gw = new GameWidget();

            gw.State = ps;
            gw.Action();

            gw.State = ss;
            gw.Action();

            Console.Read();
        }
    }
}
