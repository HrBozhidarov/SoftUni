using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var hashSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                hashSet.Add(line);
            }

            Console.WriteLine(string.Join("\n", hashSet));
        }
    }
}
