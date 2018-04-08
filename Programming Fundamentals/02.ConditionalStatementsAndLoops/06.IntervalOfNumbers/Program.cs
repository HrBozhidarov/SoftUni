using System;

namespace P06_IntervalOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());

            var start = Math.Min(num1, num2);
            var end = Math.Max(num1, num2);

            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
