using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine();



            Console.WriteLine(new Box<string>(line));
        }
    }
}
