using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // Путь к папке с файлами
        // @"C:\Users\User\source\repos\C7\C7\Files\"
        string fileFolder = @"C:\Users\Paden\source\repos\C7\C7\Files\";
        if (!Directory.Exists(fileFolder))
        {
            Directory.CreateDirectory(fileFolder);
        }
        int k = 1;
        while (k == 1)
        {
            k = Choice(fileFolder);
        }
    }

    public static void End(string fileFolder)
    {
        // Удаляем папку с файлами
        Console.WriteLine("Закрытие...");
        string s = Console.ReadLine();
        File_Class.Cleanup(fileFolder);
    }

    public static int Choice(string fileFolder)
    {
        Console.Write("Выбор задания (1-10): ");
        string a = Console.ReadLine();
        int k = 1;
        switch (a)
        {
            case "1":
                One(fileFolder);
                break;
            case "2":
                Two(fileFolder);
                break;
            case "3":
                Three(fileFolder);
                break;
            case "4":
                Four(fileFolder);
                break;
            case "5":
                Five(fileFolder);
                break;
            case "6":
                Six();
                break;
            case "7":
                Seven();
                break;
            case "8":
                Eight();
                break;
            case "9":
                Nine(fileFolder);
                break;
            case "10":
                Ten();
                break;
            default:
                k = 0;
                End(fileFolder);
                break;
        }
        return k;
    }

    public static void One(string fileFolder)
    {
        string testFile = Path.Combine(fileFolder, "test_1.txt");
        bool result = File_Class.Task1(testFile);
        Console.WriteLine("Задание 1.");
        Console.Write("Ответ: ");
        Console.WriteLine(result);
        Console.WriteLine();
    }
    public static void Two(string fileFolder)
    {
        string testFile = Path.Combine(fileFolder, "test_2.txt");
        int result = File_Class.Task2(testFile);
        Console.WriteLine("Задание 2.");
        Console.Write("Ответ: ");
        Console.WriteLine(result);
        Console.WriteLine();
    }
    public static void Three(string fileFolder)
    {
        Console.WriteLine("Задание 3.");
        bool k = true;
        int n = 5;
        char charEnd = 'a';
        while (k||n==0)
        {
            Console.Write("Введите гласную букву (англ): ");
            string a = Console.ReadLine();
            charEnd = InputOutput.ValidateChar(a);
            if (charEnd != 'q')
            {
                k = false;
            }
            else
            {
                charEnd = 'a';
                n--;
            }
        }
        string dataFile = Path.Combine(fileFolder, "test_3.1.txt");
        string testFile = Path.Combine(fileFolder, "test_3.2.txt");
        File_Class.Task3(dataFile, testFile, charEnd);
        Console.WriteLine("Выполнено.");
        Console.WriteLine("Проверьте файл Task_3.2.");
        Console.WriteLine();
    }
    public static void Four(string fileFolder)
    {
        string testFile = Path.Combine(fileFolder, "test_4.bin");
        int result = File_Class.Task4(testFile);
        Console.WriteLine("Задание 4.");
        Console.Write("Ответ: ");
        Console.WriteLine(result);
        Console.WriteLine();
    }
    public static void Five(string fileFolder)
    {
        string testFile = Path.Combine(fileFolder, "test_5.xml");
        double result = File_Class.Task5(testFile);
        Console.WriteLine("Задание 5.");
        Console.Write("Ответ: ");
        Console.WriteLine(result);
        Console.WriteLine();
    }
    
        public static void Six()
    {
        Console.WriteLine("Zadanie 6.");
        List<char> originalList = Collections_Class.FillListForTask6();
        Console.WriteLine("Nachal'nyj spisok:");
        InputOutput.PrintList(originalList);
        // Ввод символа E
        bool validInput = false;
        int attempts = 5;
        char e = 'a';  
        while (!validInput && attempts > 0)
        {
            Console.Write("Vvedite odin simvol (a/e/i/o/u ili 1/2/3/4/5): ");
            string input = Console.ReadLine();
            if (input.Length == 1)
            {
                e = input[0];
                validInput = true;
            }
            else
            {
                attempts--;
                if (attempts > 0)
                {
                    Console.WriteLine($"Nevernyj vvod. Ostalos popytok: {attempts}");
                }
                else
                {
                    Console.WriteLine("Popytki zakonchilis. Budet ispolzovan simvol 'a'.");
                    e = 'a';
                }
            }
        }
        List<char> newList = Collections_Class.Task6(originalList, e);
        Console.WriteLine("Otvet:");
        InputOutput.PrintList(newList);
        Console.WriteLine();
    }
    public static void Seven()
    {
        LinkedList<int> originalList = Collections_Class.FillLinkedList();
        Console.WriteLine("Nachal'nyj spisok:");
        InputOutput.PrintLinkedList(originalList);
        LinkedList<int> resultList = Collections_Class.Task7(originalList);
        Console.WriteLine("Otvet:");
        InputOutput.PrintLinkedList(resultList);
        Console.WriteLine();
    }
    public static void Eight()
    {
        Console.WriteLine("Zadanie 8.");
        string[] allCountries;
        List<HashSet<string>> tourists;
        HashSet<string> allVisited;
        HashSet<string> anyVisited;
        HashSet<string> noOneVisited;
        Collections_Class.Task8(out allCountries, out tourists, out allVisited, out anyVisited, out noOneVisited);
        Console.WriteLine("Spisok vsekh stran:");
        InputOutput.PrintArray(allCountries);
        Console.WriteLine();
        Console.WriteLine("Kolichestvo turistov: " + tourists.Count);
        for (int i = 0; i < tourists.Count; i++)
        {
            Console.Write("Turist " + (i + 1) + ": ");
            InputOutput.PrintHashSet(tourists[i]);
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Rezul'taty:");
        Console.Write("Strany, kotorye posetili VSE turisty: ");
        InputOutput.PrintHashSet(allVisited);
        Console.Write("Strany, kotorye posetil HOTYa BY ODIN turist: ");
        InputOutput.PrintHashSet(anyVisited);
        Console.Write("Strany, kotorye ne posetil NIKTO: ");
        InputOutput.PrintHashSet(noOneVisited);
        Console.WriteLine();
    }
    public static void Nine(string fileFolder)
    {
        Console.WriteLine("Zadanie 9.");
        Console.WriteLine("Vse: c, f, h, k, p, s, t, x");
        string testFile = Path.Combine(fileFolder, "task9.txt");
        Collections_Class.FillFileTask9(testFile);
        HashSet<char> result = Collections_Class.Task9(testFile);
        char[] sortedResult = new char[result.Count];
        result.CopyTo(sortedResult);
        for (int i = 0; i < sortedResult.Length - 1; i++)
        {
            for (int j = i + 1; j < sortedResult.Length; j++)
            {
                if (sortedResult[i] > sortedResult[j])
                {
                    char temp = sortedResult[i];
                    sortedResult[i] = sortedResult[j];
                    sortedResult[j] = temp;
                }
            }
        }
        Console.Write("Otvet: ");
        for (int i = 0; i < sortedResult.Length; i++)
        {
            Console.Write(sortedResult[i]);
            if (i < sortedResult.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
        Console.WriteLine();
    }
    public static void Ten(string fileFolder)
    {
        Console.WriteLine("Zadanie 10.");
        string testFile = Path.Combine(fileFolder, "task10.txt");
        Collections_Class.FillFileTask10(testFile, 10);
        SortedDictionary<string, string> result = Collections_Class.Task10(testFile);
        Console.WriteLine("Abiturinty, NE dopuschenye k ekzamenu:");
        foreach (var pair in result)
        {
            Console.WriteLine(pair.Value);
        }
        Console.WriteLine();
    }
}
