using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Count_of_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                var currentCount = 0;
                var currentNumber = numbers[i];

                while (i != numbers.Count && currentNumber == numbers[i])
                {
                    currentCount++;
                    i++;
                }

                i--;

                Console.WriteLine($"{currentNumber} -> {currentCount} times");
            }
        }
    }
}
