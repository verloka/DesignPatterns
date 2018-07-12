using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorCSharp
{
    //Интерфейс итератора
    interface IIterator
    {
        object First();
        object Next();
        object CurrentItem();
        bool IsDone();
    }

    //интерфейс контейнера над которым будет работать итератор
    interface IManager
    {
        int Count { get; }

        IIterator CreateIterator();

        object this[int index] { get; set; }
    }

    //конкретный обьект с которым будет работать итератр
    class NameManager : IManager
    {
        readonly ArrayList items = new ArrayList();

        public int Count { get => items.Count; }
        public object this[int index] { get => items[index]; set => items.Insert(index, value); }

        public IIterator CreateIterator()
        {
            return null;
        }
    }

    //конкретный итератор
    class NameManagerIterator : IIterator
    {
        readonly IManager manager;
        int current;

        public NameManagerIterator(IManager manager) { this.manager = manager; }

        public object CurrentItem() => manager[current];
        public object First() => manager[0];
        public bool IsDone() => current >= manager.Count;

        public object Next()
        {
            object ret = null;

            current++;

            if (current < manager.Count)
                ret = manager[current];

            return ret;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Iterator";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            NameManager nm = new NameManager();

            nm[0] = "Bill";
            nm[1] = "Rodger";
            nm[2] = "Anna";
            nm[3] = "Mary";
            nm[4] = "Jhon";

            NameManagerIterator itr = new NameManagerIterator(nm);

            Console.WriteLine("Коллекция имен:");

            object item = itr.First();
            while (!itr.IsDone())
            {
                Console.WriteLine(item);
                item = itr.Next();
            }

            Console.Read();
        }
    }
}
