namespace P17_PrintPartASCIITable
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var fisrtChar = int.Parse(Console.ReadLine());
            var secondChar = int.Parse(Console.ReadLine());

            for (char i = Convert.ToChar(fisrtChar); i <= secondChar; i++)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }
}
