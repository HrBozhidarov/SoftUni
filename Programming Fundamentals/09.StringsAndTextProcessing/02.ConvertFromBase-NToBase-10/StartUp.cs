using System;
using System.Numerics;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();
        var baseSystem = int.Parse(input[0]);
        var number = BigInteger.Parse(input[1]);

        Console.WriteLine(ConvertFromBaseNToBase10(baseSystem, number));
    }

    public static BigInteger ConvertFromBaseNToBase10(int baseSystem, BigInteger number)
    {
        BigInteger result = 0;
        var index = 0;

        while (number > 0)
        {
            var num = (number % 10) * BigInteger.Pow(baseSystem, index);
            number /= 10;
            result = num + result;
            index++;
        }

        return result;
    }
}