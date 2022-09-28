// Задача 2. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 1, 7 -> такого числа в массиве нет

int Prompt(string messege)
{
    Console.Write(messege);
    string strValue = Console.ReadLine() ?? "0";
    bool isNumber = int.TryParse(strValue, out int value);
    if (isNumber)
    {
        return value;
    }
    throw new Exception("Данное значение не возможно преобразовать в число");
}

int[,] GenerateArray(int length, int minRange, int maxRange)
{
    var array = new int[length, length];
    var random = new Random();
    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(minRange, maxRange + 1);

        }
    }
    return array;
}

int[] FindElement(int[,] inputMatrix, int searchElement, int numberEntry)
{
    int[] answer = new int[2];
    int count = 0;
    for (int i = 0; i < inputMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inputMatrix.GetLength(1); j++)
        {
            if (inputMatrix[i, j] == searchElement)
            {
                answer[0] = i;
                answer[1] = j;
                count++;
                if (numberEntry == count)
                {
                    return answer;
                }
            }
        }

    }
    return answer;
}

bool IsFound(int[] inputArray)
{
    return !(inputArray[0] == 0 && inputArray[1] == 0);
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]}\t");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

int[,] numbers = GenerateArray(4, 0, 10);
PrintArray(numbers);
int searchNum = Prompt("Введите искомое число > ");
int[] answer = FindElement(numbers, searchNum, 2);
if (!IsFound(answer))
{
    System.Console.WriteLine("такого элемента нет.");
}