namespace P06_StringsAndObjects
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string hello = "Hello";
            string world = "World";

            object concatenation = hello + " " + world;
            string typeCast = (string)concatenation;

            Console.WriteLine(typeCast);
        }
    }
}
