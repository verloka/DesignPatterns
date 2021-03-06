#include "stdafx.h"

using namespace std;

//Класс для хранения состояния обьекта
class Memento
{
private:
	friend class RealObject;

	int StateInformation;

	Memento(int si) : StateInformation(si) {}

	void SetState(int si) { StateInformation = si; }
	int GetState() { return StateInformation; }
};

//Какойто оригинальный обьект, состояние которого
//необходимо хранитть
class RealObject
{
private:
	int StateInformation;

public:
	void SetState(int si)
	{
		cout << "State is " << si << endl;
		StateInformation = si;
	}
	int GetState() { return StateInformation; }
	void SetMemento(Memento *m) { StateInformation = m->GetState(); }
	Memento* CreateMemento() { return new Memento(StateInformation); }
};

//Обьект, который несет ответсвенность за хранение 
//снапшотов обьекта
class Caretaker
{
private:
	RealObject * ro;
	vector<Memento*> history;
public:
	Caretaker(RealObject *o) : ro(o) {}
	~Caretaker()
	{
		for (auto i : history)
			delete i;

		history.clear();
	}

	void Save()
	{
		cout << "State is saved!" << endl;
		history.push_back(ro->CreateMemento());
	}
	void Undo()
	{
		cout << "State restored!" << endl;
		ro->SetMemento(history.back());
		history.pop_back();
	}
};

int main()
{
	system("color 70");
	setlocale(0, "");
	SetConsoleTitle(TEXT("Memento"));

	RealObject ro;
	Caretaker cr(&ro);

	ro.SetState(54);
	cr.Save();

	ro.SetState(33);
	cr.Save();

	ro.SetState(651);

	cr.Undo();
	cr.Undo();

	cout << "After two Undo, state is " << ro.GetState() << endl;

	system("pause");
    return 0;
}

