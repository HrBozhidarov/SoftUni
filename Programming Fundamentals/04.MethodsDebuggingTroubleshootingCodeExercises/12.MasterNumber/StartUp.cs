namespace P12_MasterNumber
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (isPolindrome(i) && SumOfDigits(i) && ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool isPolindrome(int num)
        {
            var number = num.ToString();
            var trueOrFalse = true;

            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] == number[number.Length - 1 - i])
                {
                    continue;
                }
                else
                {
                    trueOrFalse = false;
                }
            }
            return trueOrFalse;
        }

        public static bool SumOfDigits(int num)
        {
            var number = num.ToString();
            var sumOfDigits = 0;

            for (int i = 0; i < number.Length; i++)
            {
                sumOfDigits += int.Parse(number[i].ToString());
            }
            if (sumOfDigits % 7 == 0)
            {
                return true;
            }

            return false;
        }

        public static bool ContainsEvenDigit(int num)
        {
            string number = num.ToString();

            for (int i = 0; i < number.Length; i++)
            {
                int digit = int.Parse(number[i].ToString());

                if (digit % 2 == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
