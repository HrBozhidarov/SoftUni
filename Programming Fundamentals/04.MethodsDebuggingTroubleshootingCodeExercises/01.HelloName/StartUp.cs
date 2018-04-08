namespace P01_HelloName
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            PrintName(name);

        }

        public static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
