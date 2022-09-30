using System;
using System.Drawing;
using System.Net.Mail;


Boolean check = true;
int temp;
String[,] pole = new String[3, 3];
crateMatrix(pole);
if (check == true)
    main();



void main()
{
    Console.WriteLine("Добро пожаловать в игру Крестики-нолики");
    Console.WriteLine("Для хода пишите координаты, начина с 1 по 3, первое число строка, второе столбец");
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




void game(String choosSide)
{
    if (choosSide == "k")
    {
        for (temp = 0; temp < 9;)
        {
            if (check)
            {
                if (temp % 2 == 0)
                {
                    Console.WriteLine("Крестики ходят:");
                    step("X");
                    checkWin("X", "Крестики победили");
                    printMatrix(pole);
                }
                else
                {
                    Console.WriteLine("Нолики ходят:");
                    step("O");
                    checkWin("O", "Нолики победили");
                    printMatrix(pole);
                }
            }
        }
        Console.WriteLine("Ничьяяя");
    }

    if (choosSide == "n")
    {
        for (temp = 0; temp < 9;)
        {
            if (check)
            {
                if (temp % 2 == 0)
                {
                    Console.WriteLine("Нолики ходят:");
                    step("X");
                    checkWin("O", "Нолики победили");
                    printMatrix(pole);
                }
                else
                {
                    Console.WriteLine("Крестики ходят:");
                    step("O");
                    checkWin("X", "Крестики победили");
                    printMatrix(pole);
                }
            }
        }
        Console.WriteLine("Ничьяяя");
    }
}


void crateMatrix(String[,] arr)
{
    int temp = 1;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = Convert.ToString(temp);
            temp++;
        }
    }
}

void printMatrix(String[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]}  ");
        }
        Console.WriteLine();
    }
}

bool checkFill(int i, int j)
{
    if (pole[i, j] == "X") return true;
    else if (pole[i, j] == "O") return true;
    else return false;
}

void step(string xo)
{
    int i = 0;
    int j = 0;
    Console.WriteLine("Введите позицию");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("");
    if (a > 0 && a < 10)
    {
        if (a != 3 || a != 6 || a != 9)
        {
            i = a / 3;
            j = a % 3 - 1;
        }
        if (a == 3) { i = 0; j = 2; }
        if (a == 6) { i = 1; j = 2; }
        if (a == 9) { i = 2; j = 2; }


        if (checkFill(i, j))
        {
            Console.WriteLine("Позиция занята");
            if (xo == "X") step("X");
            else step("O");

        }
        else
        {
            pole[i, j] = xo;
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
    if (pole[0, 0] == xo && pole[0, 1] == xo && pole[0, 2] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[1, 0] == xo && pole[1, 1] == xo && pole[1, 2] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[2, 0] == xo && pole[2, 1] == xo && pole[2, 2] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[0, 0] == xo && pole[1, 0] == xo && pole[2, 0] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[0, 1] == xo && pole[1, 1] == xo && pole[2, 1] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[0, 2] == xo && pole[1, 2] == xo && pole[2, 2] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[0, 0] == xo && pole[1, 1] == xo && pole[2, 2] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
    else if (pole[2, 0] == xo && pole[1, 1] == xo && pole[0, 2] == xo)
    {
        Console.WriteLine(whowin);
        check = false;
    }
}