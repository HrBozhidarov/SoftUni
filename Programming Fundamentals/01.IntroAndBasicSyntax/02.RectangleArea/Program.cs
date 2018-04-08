using System;

namespace P02_RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var result = width * height;

            Console.WriteLine($"{result:F2}");
        }
    }
}
