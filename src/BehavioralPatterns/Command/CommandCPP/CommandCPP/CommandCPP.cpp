#include "stdafx.h"

using namespace std;

//Обьект над которым будут выполнятся команды
class Document
{
protected:
	vector<string> data;

public:
	Document()
	{
		//выделяем место для 20 строк
		data.reserve(20);
	}

	void InsertLine(int lineNumber, const string& line)
	{
		if (lineNumber <= data.size())
			data.insert(data.begin() + lineNumber, line);
		else
			cout << "Error" << endl;
	}
	void RemoveLine(int lineNumber)
	{
		if (!(lineNumber > data.size()))
			data.erase(data.begin() + lineNumber);
		else
			cout << "Error" << endl;
	}
	void Show()
	{
		for (int i = 0; i < data.size(); ++i)
			cout << i + 1 << ". " << data[i] << endl;
	}
	void InsertData(vector<string>& vec)
	{
		data.insert(data.begin(), vec.begin(), vec.end());
	}
	void Clear()
	{
		data.clear();
	}
	vector<string>* GetData()
	{
		return &data;
	}

	string& operator[](int x)
	{
		return data[x];
	}
};

//Интерфуйс будущих комманд
class ICommand
{
protected:
	Document * document;

public:
	virtual ~ICommand() {}
	virtual void Execute() = 0;
	virtual void UnExecute() = 0;

	void SetDocument(Document *doc)
	{
		document = doc;
	}
};

//Комманда вставки линии
class InsertCommand : public virtual ICommand
{
protected:
	int lineNumber;
	string line;

public:
	InsertCommand(int n, string& l) : lineNumber(n), line(l) {}

	virtual void Execute() override
	{
		document->InsertLine(lineNumber, line);
	}
	virtual void UnExecute() override
	{
		document->RemoveLine(lineNumber);
	}
};

//Команда очистки документа
class ClearCommand : public virtual ICommand
{
protected:
	vector<string> data;
public:
	ClearCommand(vector<string> v) : data(v) {}

	virtual void Execute() override
	{
		document->Clear();
	}
	virtual void UnExecute() override
	{
		document->InsertData(data);
	}
};

//Класс для рабты с командами над документов
class Receiver
{
	vector<ICommand*> DoneCommand;
	ICommand* command;
	Document doc;

public:
	void Insert(int n, string s)
	{
		command = new InsertCommand(n, s);
		command->SetDocument(&doc);
		command->Execute();

		DoneCommand.push_back(command);
	}
	void Clear()
	{
		command = new ClearCommand(*doc.GetData());
		command->SetDocument(&doc);
		command->Execute();

		DoneCommand.push_back(command);
	}
	void Undo()
	{
		if (DoneCommand.size() == 0)
		{
			cout << "Error" << endl;
		}
		else
		{
			command = DoneCommand.back();
			DoneCommand.pop_back();
			command->UnExecute();

			//Обязательно удалить отменоную команду
			delete command;
		}
	}
	void Show()
	{
		doc.Show();
	}
};

int main()
{
	system("color 70");
	setlocale(0, "");
	SetConsoleTitle(TEXT("Command"));

	char s = '1';
	int line, line_b;
	string str;
	Receiver res;

	while (s != 'e')
	{
		cout << "Что делать: " << endl << "1. Вставить линию" << endl << "2. Очистить" << endl << "3. Отмениить последнюю команду" << endl << "e. Выход" << endl;
		cin >> s;
		switch (s)
		{
		case '1':
			cout << "Номер лини: ";
			cin >> line;
			--line;
			cout << "Содержимое линии: ";
			cin >> str;
			res.Insert(line, str);
			break;
		case '2':
			res.Clear();
			break;
		case '3':
			res.Undo();
			break;
		}

		system("cls");

		cout << "$$$DOCUMENT$$$" << endl;
		res.Show();
		cout << "$$$DOCUMENT$$$" << endl << endl;
	}

    return 0;
}

