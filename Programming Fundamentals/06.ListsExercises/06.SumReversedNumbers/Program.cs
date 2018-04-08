namespace P06_SumReversedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            var sum = 0;

            foreach (var element in numbers)
            {
                char[] toChar = element.ToCharArray();
                Array.Reverse(toChar);
                string nums = new string(toChar);

                sum += int.Parse(nums);
            }

            Console.WriteLine(sum);
        }
    }
}
