using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.RegularExpressions;

namespace ExamSoftUni
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var pattern = @"[^@!>:-]*@([a-zA-Z]+)[^@!>:-]*:([0-9]+)[^@!:>-]*!(A|D)![^@!:>-]*->([0-9]+)[^@!:>-]*";
            var patternTown = @"@([a-zA-Z]+)";
            var destroyedPattern = @"!(A|D)!";
            var dicAttacked = new List<string>();
            var dicDestroyed = new List<string>();
            var wholeRegex = new Regex(pattern);
            var townRegex = new Regex(patternTown);
            var destroyedRegex = new Regex(destroyedPattern);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var length = 0;

                foreach (var ch in input)
                {
                    if (ch == 's' || ch == 't' || ch == 'a' || ch == 'r' || ch == 'S' || ch == 'T' || ch == 'A' || ch == 'R')
                    {
                        length++;
                    }
                }

                var inp = "";

                foreach (var ch in input)
                {
                    var character = (char)(ch - length);
                    inp += character;
                }

                input = inp;

                var isMatch = wholeRegex.IsMatch(input);

                if (!isMatch)
                {
                    continue;
                }

                var townName = townRegex.Match(input).Groups[1].Value;
                var atacckedOrDestroyed = destroyedRegex.Match(input).Groups[1].Value;

                if (atacckedOrDestroyed == "A")
                {
                    dicAttacked.Add(townName);
                }
                else
                {
                    dicDestroyed.Add(townName);
                }
            }

            Console.WriteLine($"Attacked planets: {dicAttacked.Count()}");

            foreach (var item in dicAttacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {dicDestroyed.Count()}");

            foreach (var item in dicDestroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}