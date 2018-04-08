namespace P03_EnglishNameofLastDigit
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var num = long.Parse(Console.ReadLine());

            Console.WriteLine(PrintNameOfLastDigit(num));
        }
        public static string PrintNameOfLastDigit(long num)
        {
            num = Math.Abs(num % 10);

            string name = "";

            switch (num)
            {
                case 0: name = "zero"; break;
                case 1: name = "one"; break;
                case 2: name = "two"; break;
                case 3: name = "three"; break;
                case 4: name = "four"; break;
                case 5: name = "five"; break;
                case 6: name = "six"; break;
                case 7: name = "seven"; break;
                case 8: name = "eight"; break;
                case 9: name = "nine"; break;
            }

            return name;
        }
    }
}
