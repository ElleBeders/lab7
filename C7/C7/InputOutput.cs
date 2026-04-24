using System;

public static class InputOutput
{
    public static char ValidateChar(string input)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
        if (string.IsNullOrEmpty(input))
        {
            return 'q';
        }
        char ch = input[input.Length - 1];
        char lowerChar = char.ToLower(ch);
        for (int i = 0; i < vowels.Length; i++)
        {
            if (lowerChar == vowels[i])
            {
                return lowerChar;
            }
        }
        return 'q';
    }
    public static int ValidateInt(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return -1;
        }
        int result;
        bool success = int.TryParse(input, out result);
        if (!success)
        {
            return -1;
        }
        if (result < 1 || result > 11)
        {
            return -1;
        }
        return result;
    }
    public static void PrintList(List<int> list)
    {
        Console.Write("[");
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i]);
            if (i < list.Count - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
    }
    public static void PrintLinkedList(LinkedList<int> list)
    {
        Console.Write("[");
        LinkedListNode<int> current = list.First;
        int index = 0;
        while (current != null)
        {
            Console.Write(current.Value);
            if (index < list.Count - 1)
            {
                Console.Write(", ");
            }
            current = current.Next;
            index++;
        }
        Console.WriteLine("]");
    }
    public static void PrintArray(string[] array)
    {
        Console.Write("[");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i < array.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
    }
    public static void PrintHashSet(HashSet<string> set)
    {
        Console.Write("[");
        int index = 0;
        foreach (string item in set)
        {
            Console.Write(item);
            if (index < set.Count - 1)
            {
                Console.Write(", ");
            }
            index++;
        }
        Console.WriteLine("]");
    }

}