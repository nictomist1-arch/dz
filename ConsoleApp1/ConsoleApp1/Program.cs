1
Console.WriteLine("Задание 1. Сумма побочной диагонали");
Console.Write("Введите размер квадратной матрицы n: ");
int n = int.Parse(Console.ReadLine()!);

int[,] matrix = new int[n, n];

Console.WriteLine("Введите элементы матрицы:");
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write($"matrix[{i},{j}] = ");
        matrix[i, j] = int.Parse(Console.ReadLine()!);
    }
}

int sum = 0;
for (int i = 0; i < n; i++)
{
    sum += matrix[i, n - 1 - i];
}

Console.WriteLine($"Сумма побочной диагонали: {sum}");

2
Console.WriteLine();
Console.WriteLine("Задание 2. Реверс каждой строки двумерного массива");
Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество столбцов: ");
int cols = int.Parse(Console.ReadLine()!);

int[,] array2D = new int[rows, cols];

Console.WriteLine("Введите элементы двумерного массива:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write($"array2D[{i},{j}] = ");
        array2D[i, j] = int.Parse(Console.ReadLine()!);
    }
}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols / 2; j++)
    {
        int temp = array2D[i, j];
        array2D[i, j] = array2D[i, cols - 1 - j];
        array2D[i, cols - 1 - j] = temp;
    }
}

Console.WriteLine("Массив после реверса строк:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write(array2D[i, j] + "\t");
    }
    Console.WriteLine();
}

Console.WriteLine("Минимум и максимум каждой строки:");
for (int i = 0; i < rows; i++)
{
    int min = array2D[i, 0];
    int max = array2D[i, 0];

    for (int j = 1; j < cols; j++)
    {
        if (array2D[i, j] < min)
        {
            min = array2D[i, j];
        }

        if (array2D[i, j] > max)
        {
            max = array2D[i, j];
        }
    }

    Console.WriteLine($"Строка {i + 1}: min = {min}, max = {max}");
}

int[,] transposed = new int[cols, rows];
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        transposed[j, i] = array2D[i, j];
    }
}

double[,] powerByFirstCell = new double[rows, cols];
for (int i = 0; i < rows; i++)
{
    int baseValue = array2D[i, 0];
    for (int j = 0; j < cols; j++)
    {
        powerByFirstCell[i, j] = Math.Pow(baseValue, j + 1);
    }
}

Console.WriteLine("Матрица степеней по первому числу каждой строки:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write(powerByFirstCell[i, j] + "\t");
    }
    Console.WriteLine();
}

Console.WriteLine("Транспонированная матрица:");
for (int i = 0; i < cols; i++)
{
    for (int j = 0; j < rows; j++)
    {
        Console.Write(transposed[i, j] + "\t");
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Задание 3. Банк: пополнение и снятие денег");
const string correctLogin = "admin";
const string correctPassword = "12345";

Console.WriteLine("Авторизация в банке");
Console.Write("Введите логин: ");
string login = Console.ReadLine()!;
Console.Write("Введите пароль: ");
string password = Console.ReadLine()!;

if (login != correctLogin || password != correctPassword)
{
    Console.WriteLine("Неверный логин или пароль. Доступ запрещен.");
    return;
}

Console.WriteLine("Авторизация успешна.");
Console.Write("Введите имя владельца счета: ");
string ownerName = Console.ReadLine()!;
Console.Write("Введите начальный баланс: ");
double startBalance = double.Parse(Console.ReadLine()!);

BankAccount account = new BankAccount
{
    Owner = ownerName,
    Balance = startBalance
};

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1 - Показать баланс");
    Console.WriteLine("2 - Пополнить деньги");
    Console.WriteLine("3 - Снять деньги");
    Console.WriteLine("0 - Выход");
    Console.Write("Ваш выбор: ");
    string action = Console.ReadLine()!;

    switch (action)
    {
        case "1":
            Console.WriteLine($"Владелец: {account.Owner}");
            Console.WriteLine($"Текущий баланс: {account.Balance}");
            break;

        case "2":
            Console.Write("Введите сумму пополнения: ");
            double depositAmount = double.Parse(Console.ReadLine()!);
            account.Deposit(depositAmount);
            Console.WriteLine($"Баланс после пополнения: {account.Balance}");
            break;

        case "3":
            Console.Write("Введите сумму снятия: ");
            double withdrawAmount = double.Parse(Console.ReadLine()!);
            account.Withdraw(withdrawAmount);
            Console.WriteLine($"Баланс после операции: {account.Balance}");
            break;

        case "0":
            Console.WriteLine("Работа с банком завершена.");
            return;

        default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            break;
    }
}

class BankAccount
{
    public string Owner { get; set; } = "";
    public double Balance { get; set; }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Недостаточно средств или некорректная сумма.");
        }
    }
}