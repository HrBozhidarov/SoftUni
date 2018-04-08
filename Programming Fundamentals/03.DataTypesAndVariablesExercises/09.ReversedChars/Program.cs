namespace P09_ReversedChars
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firstLetter = char.Parse(Console.ReadLine());
            var secondLetter = char.Parse(Console.ReadLine());
            var thirdLetter = char.Parse(Console.ReadLine());

            Console.WriteLine($"{thirdLetter}{secondLetter}{firstLetter}");
        }
    }
}
