namespace P01_MaxSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var counter = 1;
            var bestCounter = 1;
            var start = 0;
            var bestStart = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i-1] == numbers[i])
                {
                    counter++;

                    if (counter > bestCounter)
                    {
                        bestCounter = counter;
                        bestStart = start;
                    }
                }
                else
                {
                    start = i;
                    counter = 1;
                }
            }
            for (int i = bestStart; i <bestStart+bestCounter; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine();
        }
    }
}
