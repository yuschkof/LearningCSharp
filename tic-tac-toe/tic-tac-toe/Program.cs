using Pastel;
using System.Drawing;

string kStep = "Крестики ходят:";
string nStep = "Нолики ходят:";
string kWin = "Крестик победили, КРАСАВАА";
string nWin = "Нолик победили, КРАСАВАА";
Boolean check = true;
int temp;
string[] pole = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
if (check == true)
    main();


void main()
{
    printMatrix(pole);
    Console.WriteLine("Добро пожаловать в игру Крестики-нолики \n" +
                      "Для хода пишите цифру соответствующую вашему желанию \n" +
                      "Выберите кто ходит первым: Крестики - k, Нолики - n");
    String? choosSide = Console.ReadLine();
    int temp = 0;
    while (temp == 0)
    {
        if (choosSide == "k")
        {
            game(choosSide);
            temp = 1;

        }
        else if (choosSide == "n")
        {
            game(choosSide);
            temp = 1;
        }
        else if (choosSide != "n" && choosSide != "k")
        {
            Console.Clear();
            Console.WriteLine("Введите плиз нужную букву: k или n");
            choosSide = Console.ReadLine();
        }
    }
}

void printMatrix(string[] arr)
{
    string color = "";
    string res = "";
    for (int i = 0; i < arr.Length; i++)
    {
        
        if (arr[i] == "O")
        {
            color = "#4682B4";
        }
        else if (arr[i] == "X")
        {
            color = "#DC143C";
        }
        else
        {
            color = "#000000";
        }
        if ((i + 1) % 3 == 1)
        {
            res += $"-------------\n| {arr[i].PastelBg(color)} ";
        }
        else if ((i + 1) % 3 == 2)
        {
            res += $"| {arr[i].PastelBg(color)} |";
        }
        else
        {
            res += $" {arr[i].PastelBg(color)} |\n";
        }
    }
    res += "-------------";
    Console.WriteLine(res);
}

void game(String choosSide)
{
    Console.Clear();
    printMatrix(pole);
    if (choosSide == "k") whoFirst("X", "O", kStep, kWin, nStep, nWin);
    else whoFirst("O", "X", nStep, nWin, kStep, kWin);
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
                printMatrix(pole);
                if (checkWin(pl1, whoWin1)) Console.WriteLine(whoWin1);
            }
            else
            {
                Console.WriteLine(whoStep2);
                step(pl2);
                printMatrix(pole);
                if (checkWin(pl2, whoWin2)) Console.WriteLine(whoWin2);
                
            }
        }
    }
    if (checkWin(pl1, whoWin1) != true && checkWin(pl2, whoWin2) != true)
    {
        Console.WriteLine("Ничьяяя");
    }
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
            Console.Clear();
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

bool checkWin(string xo, string whowin)
{
    if (pole[0] == xo && pole[1] == xo && pole[2] == xo)
    {
        check = false;
        return true;
    }
    if (pole[3] == xo && pole[4] == xo && pole[5] == xo)
    {
        check = false;
        return true;
    }
    if (pole[6] == xo && pole[7] == xo && pole[8] == xo)
    {
        check = false;
        return true;
    }
    if (pole[0] == xo && pole[3] == xo && pole[6] == xo)
    {
        check = false;
        return true;
    }
    if (pole[1] == xo && pole[4] == xo && pole[7] == xo)
    {
        check = false;
        return true;
    }
    if (pole[2] == xo && pole[5] == xo && pole[8] == xo)
    {
        check = false;
        return true;
    }
    if (pole[0] == xo && pole[4] == xo && pole[8] == xo)
    {
        check = false;
        return true;
    }
    if (pole[2] == xo && pole[4] == xo && pole[6] == xo)
    {
        check = false;
        return true;
    }
    return false;
}
