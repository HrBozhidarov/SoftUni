namespace P05_BooleanVariable
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string trueOrFalse = Console.ReadLine();
            bool convertedStr = Convert.ToBoolean(trueOrFalse);

            switch (convertedStr)
            {
                case true: Console.WriteLine("Yes"); break;
                case false: Console.WriteLine("No"); break;
            }
        }
    }
}
