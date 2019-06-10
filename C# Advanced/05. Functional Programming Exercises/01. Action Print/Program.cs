using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = (name) => Console.WriteLine(name);
            var names = Console.ReadLine().Split(" ");

            foreach (var name in names)
            {
                action(name);
            }
        }
    }
}
