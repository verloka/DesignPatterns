using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterCSharp
{
    //Класс, который нужно использовать но его
    //интерфейс не подходи
    class FahrenheitSensor
    {
        public FahrenheitSensor() { }

        public float GetFahrenheitTemperature() => 99.4f;
    }

    //Интерфейс с которым будет работать Адаптер
    //для адаптирования класса к нужному виду
    interface ISensor
    {
        float GetTemperature();
    }

    //Адаптер который адаптирует под нужный интерфейс
    class Adapter : ISensor
    {
        FahrenheitSensor fs;

        public Adapter(FahrenheitSensor fs)
        {
            this.fs = fs;
        }

        //Логика адаптации
        public float GetTemperature() => (fs.GetFahrenheitTemperature() - 32.0f) * 5.0f / 9.0f;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Adapter";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            ISensor celsisu = new Adapter(new FahrenheitSensor());

            Console.WriteLine($"Fahrenheit Sensor shows temperature in Celsius: {celsisu.GetTemperature()} °C");
            Console.Read();
        }
    }
}
