namespace P01_MaxSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var count = 1;
            var bestCount = 0;
            var num = 0;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;

                    if (count > bestCount)
                    {
                        num = numbers[i];
                        bestCount = count;
                    }
                }
                else
                {
                    count = 1;
                }
            }

            if (bestCount==0)
            {
                Console.WriteLine($"{numbers[0]}");
            }
            else
            {
                for (int i = 0; i < bestCount; i++)
                {
                    Console.Write($"{num} ");
                }
            }

            Console.WriteLine();
        }
    }
}