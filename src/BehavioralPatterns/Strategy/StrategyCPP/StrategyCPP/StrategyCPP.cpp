#include "stdafx.h"

using namespace std;

//Интерфейс стратегии
class IStrategy
{
protected:
	virtual void Use() = 0;
};

//Конкретная стратегия
class WorldStrategy : public virtual IStrategy
{
protected:
	virtual void Use() override { cout << "Hello, World!\n"; }
};

//Конкретная стратегия
class MotherlandStrategy : public virtual IStrategy
{
protected:
	virtual void Use() override { cout << "Hello, Motherland!\n"; }
};

//Клиент, который выполняет стратегию
template<class IStrategy>
class Client : public virtual IStrategy
{
public:
	void UseStrategy() { this->Use(); }
};

int main()
{
	system("color 70");
	setlocale(0, "");
	SetConsoleTitle(TEXT("Strategy"));


	Client<WorldStrategy> ws;
	ws.UseStrategy();

	Client<MotherlandStrategy> mw;
	mw.UseStrategy();


	system("pause");
    return 0;
}

