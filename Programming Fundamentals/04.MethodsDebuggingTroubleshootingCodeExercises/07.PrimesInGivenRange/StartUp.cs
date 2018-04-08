namespace P07_PrimesInGivenRange
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());

            if (num1 > num2)
            {
                Console.WriteLine("empty list");

                return;
            }

            var result = CheckRangeOfPrimes(num1, num2);

            Print(result);
        }

        public static List<int> CheckRangeOfPrimes(int num1, int num2)
        {
            var numbers = new List<int>();
           
            if (num1<=1) 
            {
                num1 = 2;
            }

            for (int i = num1; i <=num2; i++)
            {
                var isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    numbers.Add(i);
                }
            }

            return numbers;
        }

        public static void Print(List<int> numbers)
        {
            Console.WriteLine(String.Join(", ",numbers));
        }
    }
}
