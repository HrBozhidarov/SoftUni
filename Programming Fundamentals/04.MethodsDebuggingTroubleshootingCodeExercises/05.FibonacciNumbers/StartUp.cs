namespace P05_FibonacciNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(FibunaciNumber(number));
        }

        public static int FibunaciNumber(int number)
        {          
            var fibNum = 1;
            var prevNum = 0;

            for (int i = 0; i < number; i++)
            {
                var oldFib = fibNum;
                fibNum = fibNum + prevNum;
                prevNum = oldFib;
            }

            return fibNum;
        }
    }
}
