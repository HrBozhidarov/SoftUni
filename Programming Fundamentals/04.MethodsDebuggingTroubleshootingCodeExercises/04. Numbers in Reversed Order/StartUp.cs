namespace P04_NumbersInReversedOrder
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var number = Console.ReadLine();

            Console.WriteLine(ReversedNumber(number));
        }

        public static string ReversedNumber(string number)
        {
            string result = "";

            for (int i = number.Length - 1; i >= 0; i--)
            {
                result += number[i];      
            }

            return result;
        }
    }
}