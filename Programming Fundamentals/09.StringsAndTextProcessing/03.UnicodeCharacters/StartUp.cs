using System;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine();

        foreach (var ch in input)
        {
            Console.Write($"\\u{((int)ch).ToString("X4").ToLower()}");
        }

        Console.WriteLine();
    }
}