namespace P13_Factorial
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(FindFactorial(number));
        }

        public static BigInteger FindFactorial(int number)
        {
            BigInteger fact = 1;

            for (int i = number; i >= 1; i--)
            {
                fact *= i;
            }

            return fact;
        }
    }
}
