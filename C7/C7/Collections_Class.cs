using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
public static class Collections_Class
{
    // ========== ЗАДАНИЕ 6 ==========
    public static List<T> Task6<T>(List<T> list, T e)
    {
        List<T> result = new List<T>(list);
        for (int i = result.Count - 1; i >= 0; i--)
        {
            if (Equals(result[i], e))
            {
                if (i + 1 < result.Count)
                {
                    if (!Equals(result[i + 1], e))
                    {
                        result.RemoveAt(i + 1);
                    }
                }
            }
        }
        return result;
    }
    // Заполнение
    public static List<char> FillListForTask6()
    {
        Random rnd = new Random();
        List<char> list = new List<char>();
        char[] allowedChars = { 'a', 'e', 'i', 'o', 'u', '1', '2', '3', '4', '5' };
        for (int i = 0; i < 15; i++)
        {
            list.Add(allowedChars[rnd.Next(allowedChars.Length)]);
        }
        return list;
    }
    // ========== ЗАДАНИЕ 7 ==========
    public static LinkedList<T> Task7<T>(LinkedList<T> list)
    {
        LinkedList<T> result = new LinkedList<T>();
        LinkedListNode<T> current = list.First;
        for (int i = 0; i < list.Count; i++)
        {
            LinkedListNode<T> next;
            if (current.Next != null)
            {
                next = current.Next;
            }
            else
            {
                next = list.First;  
            }
            if (Equals(current.Value, next.Value))
            {
                result.AddLast(current.Value);
            }
            current = current.Next;
        }
        return result;
    }
    // Заполнение
    public static LinkedList<int> FillLinkedList()
    {
        Random rnd = new Random();
        LinkedList<int> list = new LinkedList<int>();
        for (int i = 0; i < 15; i++)
        {
            list.AddLast(rnd.Next(1, 11));
        }
        return list;
    }
    // ========== ЗАДАНИЕ 8 ==========
    public static void Task8(
    out string[] allCountries,
    out List<HashSet<string>> tourists,
    out HashSet<string> allVisited,
    out HashSet<string> anyVisited,
    out HashSet<string> noOneVisited)
    {
        tourists = GenerateTouristsData(out allCountries);
        allVisited = new HashSet<string>(tourists[0]);
        anyVisited = new HashSet<string>(tourists[0]);
        for (int i = 1; i < tourists.Count; i++)
        {
            allVisited.IntersectWith(tourists[i]);
            anyVisited.UnionWith(tourists[i]);
        }
        noOneVisited = new HashSet<string>(allCountries);
        noOneVisited.ExceptWith(anyVisited);
    }
    // Заполнение
    public static List<HashSet<string>> GenerateTouristsData(out string[] allCountries)
    {
        Random rnd = new Random();
        allCountries = new string[]
        {
        "France", "Italy", "Spain", "Germany", "Japan", "Poland"
        };
        int touristCount = rnd.Next(3, 8);
        List<HashSet<string>> tourists = new List<HashSet<string>>();
        for (int i = 0; i < touristCount; i++)
        {
            int countriesCount = rnd.Next(4, 6);
            HashSet<string> visited = new HashSet<string>();
            for (int j = 0; j < countriesCount; j++)
            {
                int countryIndex = rnd.Next(0, allCountries.Length);
                visited.Add(allCountries[countryIndex]);
            }
            tourists.Add(visited);
        }
        return tourists;
    }
    // ========== ЗАДАНИЕ 9 ==========
    public static HashSet<char> Task9(string filePath)
    {
        char[] consonants = { 'p', 't', 'k', 'f', 's', 'h', 'c', 'x' };
        Dictionary<char, int> letterCount = new Dictionary<char, int>();
        for (int i = 0; i < consonants.Length; i++)
        {
            letterCount[consonants[i]] = 0;
        }
        string text = File.ReadAllText(filePath);
        string[] separators = { " ", ".", ",", "!", "?", "\n", "\r", "\t", ";", ":" };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
        }
        for (int i = 0; i < consonants.Length; i++)
        {
            char c = consonants[i];
            HashSet<string> wordsWithLetter = new HashSet<string>();
            for (int j = 0; j < words.Length; j++)
            {
                if (words[j].IndexOf(c) != -1)
                {
                    wordsWithLetter.Add(words[j]);  
                }
            }
            letterCount[c] = wordsWithLetter.Count;
        }
        HashSet<char> result = new HashSet<char>();
        for (int i = 0; i < consonants.Length; i++)
        {
            char c = consonants[i];
            if (letterCount[c] != 1)
            {
                result.Add(c);
            }
        }
        return result;
    }
    // Заполнение
    public static void FillFileTask9(string filePath)
    {
        string[] lines = new string[]
        {
        "The sea is so quiet and calm",
        "Its surface trembles gently at night",
        "It's hard to disturb its sleep",
        "Even in a storm it sounds beautiful",
        "The water in the sea is getting louder",
        "Its underwater currents are getting stronger",
        "Its boil can no longer be restrained by the surface",
        "It starts to dance",
        "Blue sea, you are beautiful",
        "Your storm is so dangerous",
        "The waves are higher above me",
        "Let them cover the sky with themselves"
        };

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < lines.Length; i++)
            {
                writer.WriteLine(lines[i]);
            }
        }
    }
    // ========== ЗАДАНИЕ 10 =========
    public static SortedDictionary<string, string> Task10(string filePath)
    {
        InputOutput.Cheking(filePath);
        SortedDictionary<string, string> notAdmitted = new SortedDictionary<string, string>();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                string[] parts = line.Split(' ');
                if (parts.Length < 4)
                {
                    continue;
                }
                string lastName = parts[0];
                string firstName = parts[1];
                string fullName = lastName + " " + firstName;
                int score1 = int.Parse(parts[2]);
                int score2 = int.Parse(parts[3]);
                if (score1 < 30 || score2 < 30)
                {
                    if (!notAdmitted.ContainsKey(lastName))
                    {
                        notAdmitted.Add(lastName, fullName);
                    }
                }
            }
        }
        return notAdmitted;
    }
    public static void FillFileTask10(string filePath, int count)
    {
        Random rnd = new Random();
        string[] lastNames = { "Ivanov", "Petrov", "Sidorov", "Kuznetsov", "Smirnov",
                               "Popov", "Vasiliev", "Sokolov", "Mikhailov", "Fedorov" };
        string[] firstNames = { "Ivan", "Petr", "Anna", "Olga", "Sergey",
                                "Dmitry", "Elena", "Maria", "Alexey", "Natalia" };
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < count; i++)
            {
                string lastName = lastNames[rnd.Next(lastNames.Length)];
                string firstName = firstNames[rnd.Next(firstNames.Length)];
                int score1 = rnd.Next(0, 101);
                int score2 = rnd.Next(0, 101);
                writer.WriteLine($"{lastName} {firstName} {score1} {score2}");
            }
        }
    }
}
