#include "stdafx.h"

using namespace std;

//Первая подсистема
class Welcome
{
public:
	void DrawStart()
	{
		cout << "#  << Start    #" << endl;
	}
	void DrawResume()
	{
		cout << "#  << Resume   #" << endl;
	}
	void DrawLoad()
	{
		cout << "#  << Load     #" << endl;
	}
	void DrawSave()
	{
		cout << "#  << Save     #" << endl;
	}
	void DrawOptions()
	{
		cout << "#  << Options  #" << endl;
	}
	void DrawExit()
	{
		cout << "#  << Exit     #" << endl;
	}
	void DrawBack()
	{
		cout << "#  << Back     #" << endl;
	}
};

//Вторая подсистема, может быть большое количество
class Decoration
{
public:
	void DrawEmptyLine()
	{
		cout << "#              #" << endl;
	}
	void DrawWallLine()
	{
		cout << "################" << endl;
	}
};

//Непосредственно фасад
class Menu
{
private:
	Welcome w;
	Decoration d;

public:
	void DrawStartMenu()
	{
		d.DrawWallLine();
		d.DrawEmptyLine();
		cout << "#   Start      #" << endl;
		d.DrawEmptyLine();

		w.DrawStart();
		w.DrawLoad();
		w.DrawOptions();
		w.DrawExit();

		d.DrawEmptyLine();
		d.DrawWallLine();
	}
	void DrawInGameMenu()
	{
		d.DrawWallLine();
		d.DrawEmptyLine();      
		cout << "#   In Game    #" << endl;
		d.DrawEmptyLine();

		w.DrawResume();
		w.DrawSave();
		w.DrawLoad();
		w.DrawOptions();
		w.DrawBack();

		d.DrawEmptyLine();
		d.DrawWallLine();
	}
};

int main()
{
	system("color 70");
	setlocale(0, "");
	SetConsoleTitle(TEXT("Facade"));

	Menu m;

	m.DrawStartMenu();

	cout << "\n\n\n\n";

	m.DrawInGameMenu();

	system("pause");
    return 0;
}

