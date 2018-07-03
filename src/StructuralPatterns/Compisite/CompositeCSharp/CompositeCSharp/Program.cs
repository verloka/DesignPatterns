using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeCSharp
{
    //Интерфейс составного обьекта
    interface IText
    {
        void Draw();
        void Add(IText element);
    }

    //Составной элемент с потомками
    class CompositeText : IText
    {
        List<IText> children;

        public CompositeText() { children = new List<IText>(); }

        public void Add(IText element) {  children.Add(element); }
        public void Remove(IText element) {  children.Remove(element); }
        public void Replace(IText oldElement, IText newElement)
        {
            var index = children.IndexOf(oldElement);
            children.Remove(oldElement);
            children.Insert(index, newElement);
        }

        public void Draw()
        {
            foreach (var item in children)
                item.Draw();
        }
    }

    //Составной обьект без детей
    class Letter : IText
    {
        char symbol;

        public Letter(char c)  { symbol = c; }

        public void Add(IText element) { throw new Exception("IText: can not be added"); }
        public void Draw() { Console.Write(symbol); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Composite";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            IText wH = new Letter('H');
            IText wE = new Letter('E');
            IText wL = new Letter('L');
            IText wO = new Letter('O');
            IText wW = new Letter('W');
            IText wR = new Letter('R');
            IText wD = new Letter('D');
            IText wI = new Letter('I');
            IText sComma = new Letter(',');
            IText sSpace = new Letter(' ');
            IText sExcl = new Letter('!');
            IText sNewLine = new Letter('\n');

            IText Hello = new CompositeText();
            Hello.Add(wH);
            Hello.Add(wE);
            Hello.Add(wL);
            Hello.Add(wL);
            Hello.Add(wO);

            IText World = new CompositeText();
            World.Add(wW);
            World.Add(wO);
            World.Add(wR);
            World.Add(wL);
            World.Add(wD);

            IText Hi = new CompositeText();
            Hi.Add(wH);
            Hi.Add(wI);

            CompositeText text = new CompositeText();

            text.Add(Hello);
            text.Add(sComma);
            text.Add(sSpace);
            text.Add(World);
            text.Add(sExcl);
            text.Add(sNewLine);

            text.Draw();

            text.Replace(Hello, Hi);

            text.Draw();

            text.Remove(sComma);
            text.Remove(sSpace);
            text.Remove(World);

            text.Draw();

            Console.Read();
        }
    }
}
