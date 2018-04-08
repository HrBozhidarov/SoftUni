namespace P10_PairsByDifference
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var diff = int.Parse(Console.ReadLine());
            var count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i]-numbers[j]==diff)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
