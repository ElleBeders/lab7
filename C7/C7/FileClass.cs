using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

public static class File_Class
{
    // ========== ЗАДАНИЕ 1 ==========
    // Читаем все числа до 0 или конца
    public static bool Task1(string filePath)
    {
        FillFileTask1(filePath, 50);
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int number = int.Parse(line);
                if (number == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }
    // Создание или перезапись файла
    private static void FillFileTask1(string filePath, int count)
    {
        Random rnd = new Random();
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < count; i++)
            {
                int randomNumber = rnd.Next(-50, 51);
                writer.WriteLine(randomNumber);
            }
        }
    }
    
    // ========== ЗАДАНИЕ 2 ==========
    // Ищем максимальное число
    public static int Task2(string filePath)
    {
        FillFileTask2(filePath, 5, 4);
        int max = int.MinValue; // Ставим самый минимум

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');
                foreach (string part in parts)
                {
                    int number = int.Parse(part);
                    if (number > max)
                    {
                        max = number;
                    }
                }
            }
        }
        return max;
    }
    // Создание или перезапись файла
    private static void FillFileTask2(string filePath, int linesCount, int numbersPerLine)
    {
        Random rnd = new Random();

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < linesCount; i++)
            {
                for (int j = 0; j < numbersPerLine; j++)
                {
                    int randomNumber = rnd.Next(-100, 101);
                    writer.Write(randomNumber);
                    if (j < numbersPerLine - 1)
                    {
                        writer.Write(' ');
                    }
                }
                writer.WriteLine();
            }
        }
    }

    // ========== ЗАДАНИЕ 3 ==========
    public static void Task3(string inputPath, string outputPath, char targetChar)
    {
        FillFileTask3(inputPath);
        using (StreamReader reader = new StreamReader(inputPath))
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Проверяем только последний символ (строка гарантированно не пустая)
                if (line[line.Length - 1] == targetChar)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
    // Создание или перезапись файла
    private static void FillFileTask3(string filePath)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
        Random rnd = new Random();
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < 20; i++)  // 20 строк
            {
                // Случайная длина строки от 1 до 15
                int lineLength = rnd.Next(1, 16);
                char[] chars = new char[lineLength];
                for (int j = 0; j < lineLength; j++)
                {
                    int randomIndex = rnd.Next(0, vowels.Length);
                    chars[j] = vowels[randomIndex];
                }
                string line = new string(chars);
                writer.WriteLine(line);
            }
        }
    }

    // ========== ЗАДАНИЕ 4 ==========
    public static int Task4(string filePath)
    {
        FillFileTask4(filePath, 20);
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                if (frequency.ContainsKey(number))
                {
                    frequency[number]++;
                }
                else
                {
                    frequency[number] = 1;
                }
            }
        }
        int pairCount = 0;
        HashSet<int> processed = new HashSet<int>();
        foreach (KeyValuePair<int, int> kvp in frequency)
        {
            int num = kvp.Key;
            if (processed.Contains(num))
            {
                continue;
            }
            if (num == 0)
            {
                continue;
            }
            int opposite = -num;
            if (frequency.ContainsKey(opposite))
            {
                int pairs = Math.Min(frequency[num], frequency[opposite]);
                pairCount += pairs;
                processed.Add(num);
                processed.Add(opposite);
            }
        }
        return pairCount;
    }
    // Создание или перезапись файла
    public static void FillFileTask4(string filePath, int count)
    {
        Random rnd = new Random();
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (int i = 0; i < count; i++)
            {
                int randomNumber = rnd.Next(-50, 51);
                writer.Write(randomNumber);
            }
        }
    }

    // ========== ЗАДАНИЕ 5 ==========
    public static double Task5(string filePath)
    {
        // 1. Заполняем файл случайными данными
        FillFileTask5(filePath);

        // 2. Читаем пассажиров из файла
        List<Passenger> passengers = ReadPassengersFromFile(filePath);

        // 3. Ищем максимальную и минимальную массу
        double maxWeight = double.MinValue;
        double minWeight = double.MaxValue;

        foreach (Passenger p in passengers)
        {
            foreach (BaggageItem item in p.Items)
            {
                if (item.Weight > maxWeight)
                {
                    maxWeight = item.Weight;
                }
                if (item.Weight < minWeight)
                {
                    minWeight = item.Weight;
                }
            }
        }

        // 4. Возвращаем разницу
        return maxWeight - minWeight;
    }
    // Чтение файла
    private static List<Passenger> ReadPassengersFromFile(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Passenger>));

        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return (List<Passenger>)serializer.Deserialize(fs);
        }
    }
    // Создание или перезапись файла
    private static void FillFileTask5(string filePath)
    {
        Random rnd = new Random();
        List<Passenger> passengers = new List<Passenger>();

        string[] passengerNames = {
        "Ivanov", "Petrov", "Sidorov", "Kuznetsov", "Smirnov",
        "Popov", "Vasiliev", "Sokolov", "Mikhailov", "Fedorov"
    };

        string[] itemNames = {
        "suitcase", "bag", "box", "backpack", "briefcase"
    };

        int passengerCount = rnd.Next(3, 9);

        for (int i = 0; i < passengerCount; i++)
        {
            Passenger p = new Passenger();

            int nameIndex = rnd.Next(0, passengerNames.Length);
            p.Name = passengerNames[nameIndex];

            int itemCount = rnd.Next(1, 6);
            p.Items = new BaggageItem[itemCount];

            for (int j = 0; j < itemCount; j++)
            {
                int itemIndex = rnd.Next(0, itemNames.Length);
                p.Items[j].Name = itemNames[itemIndex];
                p.Items[j].Weight = rnd.Next(3, 71);
            }

            passengers.Add(p);
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Passenger>));

        // НЕ создаём папку! Просто пишем файл
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, passengers);
        }
    }

    // ========== ОЧИСТКА ============
    public static void Cleanup(string folderPath)
    {
        if (Directory.Exists(folderPath))
        {
            Directory.Delete(folderPath, true);
        }
    }
}

[Serializable]
public struct BaggageItem
{
    public string Name;   // название единицы багажа
    public double Weight; // масса в кг
}

[Serializable]
public class Passenger
{
    public string Name;           // имя пассажира
    public BaggageItem[] Items;   // массив единиц багажа (требование задания!)
}