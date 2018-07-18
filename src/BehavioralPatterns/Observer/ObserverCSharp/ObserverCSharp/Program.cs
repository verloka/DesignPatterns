using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverCSharp
{

    //Интерфейс обсервера
    interface IObserver
    {
        void HandleEvent(ObservedObject o);
    }

    //Объект над котрым будет вестись наблюдение обсерверами
    class ObservedObject
    {
        string data;
        public string Data
        {
            get => data;
            set
            {
                data = value;
                Notify();
            }
        }

        List<IObserver> observers;

        public ObservedObject()
        {
            data = string.Empty;
            observers = new List<IObserver>();
        }

        void Notify()
        {
            foreach (var o in observers)
                o.HandleEvent(this);
        }

        public void AddObserver(IObserver o) => observers.Add(o);
        public void RemoveObserver(IObserver o) => observers.Remove(o);
    }

    //Обсервер котрый выводит новые данные
    //при изменении обьекта
    class ReflectorObserver : IObserver
    {
        public void HandleEvent(ObservedObject o) => Console.WriteLine($"Reflector: '{o.Data}'");
    }

    //Обсервер кторый информируе про изменения длины строки
    class LenghtObserver : IObserver
    {
        public void HandleEvent(ObservedObject o) => Console.WriteLine($"Lenght: '{o.Data.Length}'");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Observer";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            ObservedObject oo = new ObservedObject();

            ReflectorObserver ro = new ReflectorObserver();
            LenghtObserver lo = new LenghtObserver();

            oo.AddObserver(ro);
            oo.AddObserver(lo);

            oo.Data = "Hello World!";
            oo.Data = "Hi, motherland!";

            oo.RemoveObserver(lo);

            oo.Data = "Best ever!";

            Console.Read();
        }
    }
}
