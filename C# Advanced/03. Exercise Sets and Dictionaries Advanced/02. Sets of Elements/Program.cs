using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstHash = new HashSet<int>();
            var secondHash = new HashSet<int>();
            var n = input[0];
            var m = input[1];

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                firstHash.Add(num);
            }

            for (int i = 0; i < m; i++)
            {
                var num = int.Parse(Console.ReadLine());
                secondHash.Add(num);
            }

            var result = firstHash.Intersect(secondHash);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
