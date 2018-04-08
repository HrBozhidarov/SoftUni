namespace P07_MaxSequenceIncreasingElements
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var maxStart = 0;
            var maxLen = 1;
            var curentStart = 0;
            var curentLenth= 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i-1])
                {
                    curentLenth++;

                    if (curentLenth > maxLen)
                    {
                        maxLen = curentLenth;
                        maxStart = curentStart;
                    }
                }
                else
                {
                    curentStart = i;
                    curentLenth = 1;
                }
            }
            for (int i = maxStart; i < maxStart+maxLen; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine();
        }
    }
}
