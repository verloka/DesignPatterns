using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCSharp
{
    //Обьект над которым будут выполнятся команды
    class Document
    {
        List<string> Data;

        public Document()
        {
            Data = new List<string>(20);
        }

        public void InsertData(int lineNumber, string line)
        {
            if (lineNumber <= Data.Count)
                Data.Insert(lineNumber, line);
            else
                Console.WriteLine("Error");
        }
        public void RemoveLine(int lineNumber)
        {
            if (!(lineNumber > Data.Count))
                Data.RemoveAt(lineNumber);
            else
                Console.WriteLine("Error");
        }
        public void InsertData(List<string> data)
        {
            Data.InsertRange(0, data);
        }
        public void Clear()
        {
            Data.Clear();
        }
        public List<string> GetData() => Data;
    }

    //Интерфeйс будущих комманд
    interface ICommand
    {
        Document Document { get; set; }

        void Execute();
        void UnExecute();
        void SetDocument(Document doc);
    }

    //Команда вставки линии
    class InsertCommand : ICommand
    {
        public Document Document { get; set; }

        int lineNumber;
        string line;

        public InsertCommand(int l, string s)
        {
            lineNumber = l;
            line = s;
        }

        public void Execute() => Document.InsertData(lineNumber, line);
        public void UnExecute() => Document.RemoveLine(lineNumber);
        public void SetDocument(Document doc) => Document = doc;
    }

    //Команда очистки
    class ClearCommand : ICommand
    {
        public Document Document { get; set; }
        List<string> data;

        public ClearCommand(List<string> d)
        {
            data = new List<string>(d);
        }

        public void Execute() => Document.Clear();
        public void SetDocument(Document doc) => Document = doc;
        public void UnExecute() => Document.InsertData(data);
    }

    //Класс для рабoты с командами над документов
    class Receiver
    {
        List<ICommand> DoneCommand;
        Document Document;

        public Receiver()
        {
            Document = new Document();
            DoneCommand = new List<ICommand>();
        }

        public void Insert(int n, string l)
        {
            ICommand command = new InsertCommand(n, l);
            command.SetDocument(Document);
            command.Execute();

            DoneCommand.Add(command);
        }
        public void Clear()
        {
            ICommand command = new ClearCommand(Document.GetData());
            command.SetDocument(Document);
            command.Execute();

            DoneCommand.Add(command);
        }

        public void Undo()
        {
            if (DoneCommand.Count == 0)
                Console.WriteLine("Error");
            else
            {
                var command = DoneCommand.Last();
                command.UnExecute();

                DoneCommand.Remove(command);
            }
        }
        public void Show()
        {
            Console.WriteLine("$$$DOCUMENT$$$");
            foreach (var item in Document.GetData())
                Console.WriteLine(item);
            Console.WriteLine("$$$DOCUMENT$$$\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Command";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Receiver res = new Receiver();
            char s = '1';
            int line;
            string str;

            while (s != 'e')
            {
                Console.WriteLine("Что делать: ");
                Console.WriteLine("1. Вставить линию");
                Console.WriteLine("2. Очистить");
                Console.WriteLine("3. Отмениить последнюю команду");
                Console.WriteLine("e. Выход");

                s = Console.ReadLine()[0];

                switch (s)
                {
                    case '1':
                        Console.WriteLine("Номер лини: ");
                        int.TryParse(Console.ReadLine(), out line);
                        --line;
                        Console.WriteLine("Содержимое линии: ");
                        str = Console.ReadLine();
                        res.Insert(line, str);
                        break;
                    case '2':
                        res.Clear();
                        break;
                    case '3':
                        res.Undo();
                        break;
                }

                Console.Clear();
                res.Show();
            }
        }
    }
}
