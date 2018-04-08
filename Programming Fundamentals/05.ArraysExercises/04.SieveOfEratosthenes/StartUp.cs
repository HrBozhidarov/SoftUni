namespace P04_SieveOfEratosthenes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = new int[n+1];
            var primes = new bool[numbers.Length];

            FindAllPrimesInRange(numbers, n, primes);

            for (int i = 2; i < numbers.Length; i++)
            {
                if (!primes[i])
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            Console.WriteLine();
        }

        static void FindAllPrimesInRange(int[] numbers, int n, bool[] primes)
        {
            var result = 0L;

            for (int i = 2; i < numbers.Length; i++)
            {
                numbers[i] = i;

                for (int j = 2; j <= Math.Sqrt(n); j++)
                {
                    result = numbers[i] * j;

                    if (result <= n)
                    {
                        primes[result] = true;
                    }
                }
            }        
        }    
    }
}
