using System;
using System.Numerics;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();
        var baseSystem = int.Parse(input[0]);
        var number = BigInteger.Parse(input[1]);

        Console.WriteLine(ConvertFromBase10ToBaseN(baseSystem, number));
    }

    public static string ConvertFromBase10ToBaseN(int baseSystem, BigInteger number)
    {
        var result = "";

        while (number > 0)
        {
            var num = number % baseSystem;
            number /= baseSystem;
            result = num + result;
        }

        return result;
    }
}