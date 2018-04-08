using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();

        var firstString = input[0];
        var secondString = input[1];

        Console.WriteLine(IsWordExchangeable(firstString, secondString).ToString().ToLower());
    }

    private static bool IsWordExchangeable(string firstString, string secondString)
    {
        var dictionary = new Dictionary<char, char>();

        var minLength = Math.Min(firstString.Length, secondString.Length);
        var maxLength = Math.Max(firstString.Length, secondString.Length);

        for (int i = 0; i < minLength; i++)
        {
            var ch1 = firstString[i];
            var ch2 = secondString[i];

            if (!dictionary.ContainsKey(ch1))
            {

                if (dictionary.ContainsValue(ch2))
                {
                    return false;
                }

                dictionary[ch1] = ch2;
            }
            else
            {
                if (dictionary[ch1] != ch2)
                {
                    return false;
                }
            }
        }

        if (firstString.Length == maxLength && secondString.Length < maxLength)
        {
            for (int i = minLength; i < maxLength; i++)
            {
                if (!dictionary.ContainsKey(firstString[i]))
                {
                    return false;
                }
            }
        }
        else
        {
            for (int i = minLength; i < maxLength; i++)
            {
                if (!dictionary.ContainsValue(secondString[i]))
                {
                    return false;
                }
            }
        }

        return true;
    }
}