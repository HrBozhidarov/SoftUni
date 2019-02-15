using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Longest_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine(string.Join(" ", ReturnLongestSequenceFromEquelNumbers(numbers)));
        }

        private static List<int> ReturnLongestSequenceFromEquelNumbers(List<int> numbers)
        {
            var index = 0;
            var maxCount = 1;
            var currentCount = 1;

            if (numbers.Count == 1)
            {
                Console.WriteLine(numbers[index]);

                return new List<int>() { numbers[index] };
            }

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] == numbers[i])
                {
                    currentCount++;

                    if (currentCount > maxCount)
                    {
                        index = i;
                        maxCount = currentCount;
                    }
                }
                else
                {
                    currentCount = 1;
                }
            }

            var result = new List<int>();

            for (int i = 0; i < maxCount; i++)
            {
                result.Add(numbers[index]);
            }

            return result;
        }
    }
}
