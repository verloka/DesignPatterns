using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodCSharp
{
    //Абстрактный класс сортировки
    //"интерфейс"
    abstract class ShellSort
    {
        public void Sort(List<int> arr)
        {
            for (int g = arr.Count / 2; g > 0; g /= 2)
                for (int i = g; i < arr.Count; i++)
                    for (int j = i - g; j >= 0; j -= g)
                        if (Predicate(arr[j], arr[j + g]))
                            Swap(arr, j, j + g);
        }

        protected void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        protected abstract bool Predicate(int a, int b);
    }

    //Законченная сортировка с переопределенным
    //template method'ом
    class ShellSortUp : ShellSort
    {
        protected override bool Predicate(int a, int b) => a > b;
    }

    //Законченная сортировка с переопределенным
    //template method'ом
    class ShellSortDown : ShellSort
    {
        protected override bool Predicate(int a, int b) => a < b;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Template method";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            List<int> arr = new List<int>()
            {
                5,
                356,
                7,
                1,
                7,
                1,
                8,
                7211,
                762,
                1,
                672,
                6,
                88
            };

            ShellSortUp up = new ShellSortUp();
            up.Sort(arr);
            Console.WriteLine("ShellSortUp:");
            foreach (var item in arr)
                Console.Write($"{item} ");

            ShellSortDown down = new ShellSortDown();
            down.Sort(arr);
            Console.WriteLine("\nShellSortDown:");
            foreach (var item in arr)
                Console.Write($"{item} ");

            Console.Read();
        }
    }
}
