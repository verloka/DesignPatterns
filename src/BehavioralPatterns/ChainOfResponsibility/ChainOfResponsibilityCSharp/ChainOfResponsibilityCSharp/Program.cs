using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityCSharp
{
    //Тип, по которому определяется каком обработчику 
    //отдать на обработку
    enum CarType
    {
        Truck = 0,
        Sedan,
        Coupe
    }

    //Интерфейс обьекта который будет обрабатывать
    interface ICarHundler
    {
        ICarHundler Successor { get; set; }
        void SetSuccessor(ICarHundler Successor);
        void HandleRequest(Car car);
    }

    //Обьект для обработки
    class Car
    {
        public string Number { get; set; }
        public CarType CarType { get; set; }

        public Car(string Number, CarType CarType)
        {
            this.Number = Number;
            this.CarType = CarType;
        }
    }

    //Обработчики, конкретные
    class HundlerTruck : ICarHundler
    {
        public ICarHundler Successor { get; set; }

        public void HandleRequest(Car car)
        {
            if (car.CarType == CarType.Truck)
                Console.WriteLine($"Car with number {car.Number} was handled in HundlerTruck");
            else if (Successor != null)
                Successor.HandleRequest(car);
        }

        public void SetSuccessor(ICarHundler Successor)
        {
            this.Successor = Successor;
        }
    }

    class HundlerSedan : ICarHundler
    {
        public ICarHundler Successor { get; set; }

        public void HandleRequest(Car car)
        {
            if (car.CarType == CarType.Sedan)
                Console.WriteLine($"Car with number {car.Number} was handled in HundlerSedan");
            else if (Successor != null)
                Successor.HandleRequest(car);
        }

        public void SetSuccessor(ICarHundler Successor)
        {
            this.Successor = Successor;
        }
    }

    class HundlerCoupe : ICarHundler
    {
        public ICarHundler Successor { get; set; }

        public void HandleRequest(Car car)
        {
            if (car.CarType == CarType.Coupe)
                Console.WriteLine($"Car with number {car.Number} was handled in HundlerCoupe");
            else if (Successor != null)
                Successor.HandleRequest(car);
        }

        public void SetSuccessor(ICarHundler Successor)
        {
            this.Successor = Successor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Chain of responsibility";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            ICarHundler truckHandler = new HundlerTruck();
            ICarHundler sedanHandler = new HundlerSedan();
            ICarHundler coupeHandler = new HundlerCoupe();

            truckHandler.SetSuccessor(sedanHandler);
            sedanHandler.SetSuccessor(coupeHandler);

            Car[] cars =
            {
                new Car("er34212re", CarType.Coupe),
                new Car("er34212gh", CarType.Coupe),
                new Car("er34213re", CarType.Sedan),
                new Car("er95412re", CarType.Coupe),
                new Car("er34212xe", CarType.Truck),
                new Car("er34212re", CarType.Coupe),
                new Car("er34212ge", CarType.Sedan),
                new Car("er34212re", CarType.Coupe),
                new Car("er34212nv", CarType.Sedan),
                new Car("er34212jh", CarType.Coupe),
                new Car("er34212qd", CarType.Truck),
                new Car("er34425re", CarType.Sedan),
                new Car("er34874re", CarType.Sedan),
                new Car("er93442re", CarType.Sedan)
            };

            foreach (var item in cars)
            {
                truckHandler.HandleRequest(item);
            }

            Console.Read();
        }
    }
}
