using System;
using System.Numerics;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();

        var firstString = input[0];
        var secondString = input[1];
        BigInteger result = 0;

        if (firstString.Length > secondString.Length)
        {
            result = SumOfCharacters(firstString, secondString);
        }
        else
        {
            result = SumOfCharacters(secondString, firstString);
        }

        Console.WriteLine(result);
    }

    private static BigInteger SumOfCharacters(string firstString, string secondString)
    {
        BigInteger sum = 0;

        for (int i = 0; i < secondString.Length; i++)
        {
            sum += (firstString[i] * secondString[i]);
        }

        for (int i = secondString.Length; i < firstString.Length; i++)
        {
            sum += firstString[i];
        }

        return sum;
    }
}