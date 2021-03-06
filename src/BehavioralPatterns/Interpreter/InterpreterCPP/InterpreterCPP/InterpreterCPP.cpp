#include "stdafx.h"

using namespace std;

//Интерфейс для римских чисел числа
class IRomanNumber
{
public:
	void Interpred(string &input, int &total)
	{
		int index;
		index = 0;
		if (!strncmp(input.c_str(), Nine().c_str(), 2))
		{
			total += 9 * Multiplier();
			index += 2;
		}
		else if (!strncmp(input.c_str(), Four().c_str(), 2))
		{
			total += 4 * Multiplier();
			index += 2;
		}
		else
		{
			if (input[0] == Five())
			{
				total += 5 * Multiplier();
				index = 1;
			}
			else
				index = 0;
			for (int end = index + 3; index < end; index++)
				if (input[index] == One())
					total += 1 * Multiplier();
				else
					break;
		}

		input = &(input[index]);

		//strcpy(input, &(input[index]));
	}

protected:
	virtual char One() = 0;
	virtual string Four() = 0;
	virtual char Five() = 0;
	virtual string Nine() = 0;
	virtual int Multiplier() = 0;
};

//Конкретные числа
class ThousandNumber : public virtual IRomanNumber
{
protected:
	virtual char One() override { return 'M'; }
	virtual string Four() override { return ""; }
	virtual char Five() override { return '\0'; }
	virtual string Nine() override { return ""; }
	virtual int Multiplier() override { return 1000; }
};

class HundredNumber : public virtual IRomanNumber
{
protected:
	virtual char One() override { return 'C'; }
	virtual string Four() override { return "CD"; }
	virtual char Five() override { return 'D'; }
	virtual string Nine() override { return "CM"; }
	virtual int Multiplier() override { return 100; }
};

class TenNumber : public virtual IRomanNumber
{
protected:
	virtual char One() override { return 'X'; }
	virtual string Four() override { return "XL"; }
	virtual char Five() override { return 'L'; }
	virtual string Nine() override { return "XC"; }
	virtual int Multiplier() override { return 10; }
};

class OneNumber : public virtual IRomanNumber
{
protected:
	virtual char One() override { return 'I'; }
	virtual string Four() override { return "IV"; }
	virtual char Five() override { return 'V'; }
	virtual string Nine() override { return "IX"; }
	virtual int Multiplier() override { return 1; }
};

//нтерпретатор
class Interpreter
{
protected:
	IRomanNumber * n1000;
	IRomanNumber* n100;
	IRomanNumber* n10;
	IRomanNumber* n1;

public:
	Interpreter()
	{
		n1000 = new ThousandNumber();
		n100 = new HundredNumber();
		n10 = new TenNumber();
		n1 = new OneNumber();
	}
	~Interpreter()
	{
		delete n1000;
		delete n100;
		delete n10;
		delete n1;
	}

	int Interpred(string input)
	{
		int total = 0;

		n1000->Interpred(input, total);
		n100->Interpred(input, total);
		n10->Interpred(input, total);
		n1->Interpred(input, total);

		return strcmp(input.c_str(), "") ? 0 : total;
	}
};


int main()
{
	system("color 70");
	setlocale(0, "");
	SetConsoleTitle(TEXT("Interpreter"));

	Interpreter intr;

	string input;
	cout << "e. Выход" << endl << "Введите римское число: ";

	while (cin >> input)
	{
		cout << "Введенное число: " << intr.Interpred(input) << endl;
		cout << "Введите римское число: ";
	}

	return 0;
}

