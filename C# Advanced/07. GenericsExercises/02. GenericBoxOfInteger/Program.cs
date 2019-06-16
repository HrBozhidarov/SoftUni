using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var num = int.Parse(Console.ReadLine());

            Console.WriteLine(new Box<int>(num));
        }
    }
}
