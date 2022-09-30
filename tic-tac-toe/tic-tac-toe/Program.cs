using System;
using System.Drawing;
using System.Net.Mail;


Boolean check = true;
int temp;
string[] pole = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
if (check == true)
    main();


void main()
{
    Console.WriteLine("Добро пожаловать в игру Крестики-нолики");
    Console.WriteLine("Для хода пишите цифру соответствующую вашему желанию");
    Console.WriteLine("Выберите кто ходит первым: Крестики - k, Нолики - n");
    String? choosSide = Console.ReadLine();
    int temp = 0;
    while (temp == 0)
    {
        if (choosSide == "k")
        {
            printMatrix(pole);
            game(choosSide);
            temp = 1;

        }
        else if (choosSide == "n")
        {
            printMatrix(pole);
            game(choosSide);
            temp = 1;
        }
        else if (choosSide != "n" && choosSide != "k")
        {
            Console.WriteLine("Введите плиз нужную букву");
            choosSide = Console.ReadLine();
        }
    }
}


void whoFirst(string pl1, string pl2, string whoStep1, string whoWin1, string whoStep2, string whoWin2)
{
    for (temp = 0; temp < 9;)
    {
        if (check)
        {
            if (temp % 2 == 0)
            {
                Console.WriteLine(whoStep1);
                step(pl1);
                checkWin(pl1, whoWin1);
                printMatrix(pole);
            }
            else
            {
                Console.WriteLine(whoStep2);
                step(pl2);
                checkWin(pl2, whoWin2);
                printMatrix(pole);
            }
        }
    }
    Console.WriteLine("Ничьяяя");
}

void game(String choosSide)
{
    if (choosSide == "k")
    {
        whoFirst("X", "O", "Крестики ходят:", "Крестики победили", "Нолики ходят:", "Нолики победили");
    }
    else
    {
        whoFirst("O", "X", "Нолики ходят:", "Нолики победили", "Крестики ходят:", "Крестики победили");
    }
}

void printMatrix(string[] arr)
{

    string msg = "";
    for (int i = 0; i < arr.Length; i++)
    {
        if ((i + 1) % 3 == 1)
        {
            msg += $"-------------\n| {arr[i]} ";
        }
        else if ((i + 1) % 3 == 2)
        {
            msg += $"| {arr[i]} |";
        }
        else
        {
            msg += $" {arr[i]} |\n";
        }
    }
    msg += "-------------";
    Console.WriteLine(msg);
}

bool checkFill(int i)
{
    if (pole[i] == "X") return true;
    else if (pole[i] == "O") return true;
    else return false;
}

void step(string xo)
{
    Console.WriteLine("Введите позицию");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("");
    if (a > 0 && a < 10)
    {
        if (checkFill(a - 1))
        {
            Console.WriteLine("Позиция занята");
            if (xo == "X") step("X");
            else step("O");

        }
        else
        {
            pole[a - 1] = xo;
            temp++;
        }
    }
    else
    {
        Console.WriteLine("Введите числа от 1 до 9");
        if (xo == "X") step("X");
        else step("O");
    }
}

void checkWin(string xo, string whowin)
{
    if (pole[0] == xo && pole[1] == xo && pole[2] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[3] == xo && pole[4] == xo && pole[5] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[6] == xo && pole[7] == xo && pole[8] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[0] == xo && pole[3] == xo && pole[6] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[1] == xo && pole[4] == xo && pole[7] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[2] == xo && pole[5] == xo && pole[8] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[0] == xo && pole[4] == xo && pole[8] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[2] == xo && pole[4] == xo && pole[6] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
}