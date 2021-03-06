#include "stdafx.h"

using namespace std;

//Класс, который нужно использовать но его
//интерфейс не подходит
class FahrenheitSensor
{
public:
	FahrenheitSensor() {};
	virtual ~FahrenheitSensor() {};

	float GetFahrenheitTemperature()
	{
		//Какие-то действия
		return 86.5f;
	}
};

//Интерфейс с которым будет работать Адаптер
//для адаптирования класса к нужному виду
class Sensor
{
public:
	virtual ~Sensor() {};
	float virtual GetTemperature() = 0;
};

class Adapter : public virtual Sensor
{
private:
	FahrenheitSensor * fSensor;

public:
	Adapter(FahrenheitSensor* p) : fSensor(p) {}
	~Adapter() { delete fSensor; }

	virtual float GetTemperature() override
	{
		//Логика преобразовывания
		return (fSensor->GetFahrenheitTemperature() - 32.0)*5.0 / 9.0;
	}

};

int main()
{
	system("color 70");
	setlocale(0, "");
	SetConsoleTitle(TEXT("Adapter"));

	Sensor* s = new Adapter(new FahrenheitSensor);

	cout << "Fahrenheit Sensor shows temperature in Celsius: " << s->GetTemperature() << " °C" << endl;

	delete s;

	system("pause");
    return 0;
}

