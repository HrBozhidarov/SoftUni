namespace _09.IndexOfLettersShortSolution
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string word = Console.ReadLine();
            foreach (var element in word)
                Console.WriteLine($"{element} -> {element - 'a'}");
        }
    }
}
