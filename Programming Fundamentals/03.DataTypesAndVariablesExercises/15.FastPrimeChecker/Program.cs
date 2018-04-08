namespace P15_FastPrimeChecker
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var range = int.Parse(Console.ReadLine());

            for (int i = 2; i <= range; i++)
            {
                bool prime = true;

                for (int j = 2; j <= i/2; j++)
                {
                    if (i % j == 0)
                    {
                        prime = false;
                    }
                }

                Console.WriteLine($"{i} -> {prime}");
            }
        }
    }
}
