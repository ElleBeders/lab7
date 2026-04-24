using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

public static class Collections_Class
{
    // ========== ЗАДАНИЕ 6 ==========
    public static List<int> Task6(List<int> list, int e)
    {
        // Создаём копию списка, чтобы не изменять оригинал
        List<int> result = new List<int>(list);
        for (int i = result.Count - 1; i >= 0; i--)
        {
            if (result[i] == e)
            {
                if (i < result.Count - 1)
                {
                    if (result[i + 1] != e)
                    {
                        result.RemoveAt(i + 1);
                    }
                }
            }
        }
        return result;
    }
    // Заполнение
    public static List<int> FillList()
    {
        Random rnd = new Random();
        List<int> list = new List<int>();
        for (int i = 0; i < 15; i++)
        {
            list.Add(rnd.Next(1, 11));
        }
        return list;
    }
    // ========== ЗАДАНИЕ 7 ==========
    public static LinkedList<int> Task7(LinkedList<int> list)
    {
        LinkedList<int> result = new LinkedList<int>();
        LinkedListNode<int> current = list.First;
        for (int i = 0; i < list.Count; i++)
        {
            LinkedListNode<int> next;
            if (current.Next != null)
            {
                next = current.Next;
            }
            else
            {
                next = list.First;  
            }
            if (current.Value == next.Value)
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
        string[] separators = { " ", ".", ",", "!", "?", "\n", "\r", "\t" };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
        }
        for (int i = 0; i < consonants.Length; i++)
        {
            char c = consonants[i];
            HashSet<int> wordIndices = new HashSet<int>();
            for (int j = 0; j < words.Length; j++)
            {
                if (words[j].IndexOf(c) != -1)
                {
                    wordIndices.Add(j);
                }
            }
            letterCount[c] = wordIndices.Count;
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
    public static SortedDictionary<string, string> Task10(
    out List<KeyValuePair<string, string>> applicants,
    out int[] scores1,
    out int[] scores2)
    {
        applicants = GenerateApplicantsData(out scores1, out scores2);
        SortedDictionary<string, string> notAdmitted = new SortedDictionary<string, string>();
        for (int i = 0; i < applicants.Count; i++)
        {
            if (scores1[i] < 30 || scores2[i] < 30)
            {
                string lastName = applicants[i].Key;
                string fullName = applicants[i].Value;
                if (!notAdmitted.ContainsKey(lastName))
                {
                    notAdmitted.Add(lastName, fullName);
                }
            }
        }
        return notAdmitted;
    }
    // Заполнение
    public static List<KeyValuePair<string, string>> GenerateApplicantsData(out int[] scores1, out int[] scores2)
    {
        Random rnd = new Random();
        string[] lastNames = { "Ivanov", "Petrov", "Sidorov", "Kuznetsov", "Smirnov", "Popov", "Vasiliev", "Sokolov", "Mikhailov", "Fedorov" };
        string[] firstNames = { "Ivan", "Petr", "Anna", "Olga", "Sergey", "Dmitry", "Elena", "Maria", "Alexey", "Natalia" };
        int count = rnd.Next(5, 16);
        List<KeyValuePair<string, string>> applicants = new List<KeyValuePair<string, string>>();
        scores1 = new int[count];
        scores2 = new int[count];
        for (int i = 0; i < count; i++)
        {
            string lastName = lastNames[rnd.Next(lastNames.Length)];
            string firstName = firstNames[rnd.Next(firstNames.Length)];
            string fullName = lastName + " " + firstName;
            scores1[i] = rnd.Next(0, 101);
            scores2[i] = rnd.Next(0, 101);
            applicants.Add(new KeyValuePair<string, string>(lastName, fullName));
        }
        return applicants;
    }
}