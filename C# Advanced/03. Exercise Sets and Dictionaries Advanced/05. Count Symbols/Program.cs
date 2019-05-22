using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var dic = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                if (!dic.ContainsKey(ch))
                {
                    dic[ch] = 0;
                }

                dic[ch]++;
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
