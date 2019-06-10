using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = (name) => Console.WriteLine("Sir " + name);
            var names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                action(name);
            }
        }
    }
}
