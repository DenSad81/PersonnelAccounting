using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        const char AddFile = '1';
        const char PrintAllFiles = '2';
        const char DeleteFile = '3';
        const char SerchInFiles = '4';
        const char Exit = '5';

        string[] fullNames = new string[5] { "Aa Zz", "Aa Xx", "Cc Kk", "Aa Pp", "Ee Ww" };
        string[] fullJobNames = new string[5] { "a", "b", "c", "d", "e" };
        char choiceOfMenu;
        bool isRun = true;

        while (isRun)
        {
            Console.WriteLine($"Меню: {AddFile}-добавить досье;");
            Console.WriteLine($"      {PrintAllFiles}-вывести все досье;");
            Console.WriteLine($"      {DeleteFile}-удалить досье;");
            Console.WriteLine($"      {SerchInFiles}-поиск по фамилии;");
            Console.WriteLine($"      {Exit}-выход;");
            Console.Write("Ваш выбор: ");
            choiceOfMenu = Convert.ToChar(Console.ReadLine());

            switch (choiceOfMenu)
            {
                case AddFile:
                    AddUserFile(ref fullNames, ref fullJobNames);
                    break;

                case PrintAllFiles:
                    PrintAllUserFiles(fullNames, fullJobNames);
                    break;

                case DeleteFile:
                    DeleteUserFile(ref fullNames, ref fullJobNames);
                    break;

                case SerchInFiles:
                    SearchInUserFile(fullNames);
                    break;

                case Exit:
                    isRun = false;
                    break;
            }
        }
    }

    static void AddUserFile(ref string[] arrayName, ref string[] arrayVacancy)
    {
        string inputData;

        Console.Write("Введите ФИО человека: ");
        inputData = Console.ReadLine();
        AddElementInArrayOfString(ref arrayName, inputData);

        Console.Write("Введите должность человека: ");
        inputData = Console.ReadLine();
        AddElementInArrayOfString(ref arrayVacancy, inputData);
    }

    static void AddElementInArrayOfString(ref string[] array, string data)
    {
        string[] tempArray = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
            tempArray[i] = array[i];

        tempArray[tempArray.Length - 1] = data;
        array = tempArray;
    }

    static void AddElementInArrayOfInt(ref int[] array, int data)
    {
        int[] tempArray = new int[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
            tempArray[i] = array[i];

        tempArray[tempArray.Length - 1] = data;
        array = tempArray;
    }

    static void PrintAllUserFiles(string[] array1, string[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
            Console.Write($"{i + 1}: {array1[i]} - {array2[i]};  ");

        Console.WriteLine();
    }

    static void DeleteUserFile(ref string[] array1, ref string[] array2)
    {
        Console.Write("Введите позицию для удаления: ");
        int positionInArray = Convert.ToInt32(Console.ReadLine());

        positionInArray--;

        if (array1.Length != array2.Length)
        {
            Console.WriteLine("Длины списков не равны!!!");
            return;
        }

        if (positionInArray < 0 || positionInArray >= array1.Length)
        {
            Console.WriteLine("Невозможно удалить то чего нет");
            return;
        }

        DeleteElementInArray(ref array1, positionInArray);
        DeleteElementInArray(ref array2, positionInArray);
    }

    static void DeleteElementInArray(ref string[] array, int position)
    {

        for (int i = position; i < (array.Length - 1); i++)
            array[i] = array[i + 1];

        string[] tempArray = new string[array.Length - 1];

        for (int i = 0; i < tempArray.Length; i++)
            tempArray[i] = array[i];

        array = tempArray;
    }

    static void SearchInUserFile(string[] names)
    {
        int[] resultsOfSerch;
        Console.Write("Введите ФИО человека: ");
        string name = Console.ReadLine();

        SearchElementInArray(names, out resultsOfSerch, name);

        if (resultsOfSerch.Length > 0)
        {
            Console.Write($"Человек {name} находится под номером: ");

            for (int i = 0; i < resultsOfSerch.Length; i++)
                Console.Write($" {resultsOfSerch[i]}");

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"В списках не значится");
        }
    }

    static void SearchElementInArray(string[] array, out int[] results, string data)
    {
        results = new int[0];

        for (int i = 0; i < array.Length; i++)
        {
            string[] subArray = array[i].Split(' ');

            if (subArray[0] == data)
                AddElementInArrayOfInt(ref results, i + 1);
        }
    }
}