using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var removeNumber = int.Parse(Console.ReadLine());
            Func<List<int>, int, List<int>> removeFromList = (list, num) => list.Where(x => x % num != 0).Reverse().ToList();

            Console.WriteLine(string.Join(" ", removeFromList(numbers, removeNumber)));
        }
    }
}
