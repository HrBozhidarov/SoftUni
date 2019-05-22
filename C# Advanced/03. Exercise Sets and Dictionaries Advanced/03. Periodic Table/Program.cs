using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sortedDictionary = new SortedDictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();

                for (int j = 0; j < line.Length; j++)
                {
                    sortedDictionary[line[j]] = 1;
                }
            }

            Console.WriteLine(string.Join(" ", sortedDictionary.Keys));
        }
    }
}
