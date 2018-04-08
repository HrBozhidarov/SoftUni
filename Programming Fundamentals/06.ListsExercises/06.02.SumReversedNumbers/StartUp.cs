namespace _06._02.SumReversedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                var rev = 0;
                while (nums[i]>0)
                {
                    var last = nums[i] % 10;
                    rev = rev * 10 + last;
                    nums[i] /= 10;
                }
                sum += rev;
            }
            Console.WriteLine(sum);
        }
    }
}
