#include "stdafx.h"

using namespace std;

//Абстрактный класс продукта
class Drink
{
public:
	virtual ~Drink() {}

	virtual string GetName() = 0;
};

//Класс конкретного продукта
class TeaDrink: public virtual Drink
{
public:
	string GetName() override
	{
		return "Lipton";
	}
};

//Класс конкретного продукта
class CoffeDrink : public virtual Drink
{
public:
	string GetName() override
	{
		return "Jacobs";
	}
};

//Класс конкретного продукта
class PepsiDrink : public virtual Drink
{
public:
	string GetName() override
	{
		return "Pepsi";
	}
};

//Создатель, содержит фабричный метод
class Creator
{
public:
	virtual Drink* FactoryMethod() = 0;
};

//Конкретный создатель со своей реализацией фабричного метода
class CreatorTeaDrink : public virtual Creator
{
public:
	virtual Drink* FactoryMethod() override { return new TeaDrink(); }
};

//Конкретный создатель со своей реализацией фабричного метода
class CreatorCoffeDrink : public virtual Creator
{
public:
	virtual Drink* FactoryMethod() override { return new CoffeDrink(); }
};

//Конкретный создатель со своей реализацией фабричного метода
class CreatorPepsiDrink : public virtual Creator
{
public:
	virtual Drink* FactoryMethod() override { return new PepsiDrink(); }
};

int main()
{
	system("color 70");
	setlocale(0, "");
	SetConsoleTitle(TEXT("Factory Method"));

	CreatorTeaDrink creatorTeaDrink;
	CreatorCoffeDrink creatorCoffeDrink;
	CreatorPepsiDrink creatorPepsiDrink;

	vector<Creator*> creators;

	creators.push_back(&creatorTeaDrink);
	creators.push_back(&creatorCoffeDrink);
	creators.push_back(&creatorPepsiDrink);

	for (vector<Creator*>::iterator it = creators.begin(); it != creators.end(); it++)
	{
		Drink* dr = (*it)->FactoryMethod();
		cout << dr->GetName() << endl;
		delete dr;
	}

	system("pause");

    return 0;
}

