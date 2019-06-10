using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToList();
            Func<List<string>, int, List<string>> func = (allNames, length) => allNames.Where(x => x.Length <= length).ToList();

            Console.WriteLine(string.Join("\n", func(names, n)));
        }
    }
}
