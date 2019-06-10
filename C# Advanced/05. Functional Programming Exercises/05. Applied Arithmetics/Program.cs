using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var line = Console.ReadLine();
            Func<int[], int[]> add = (arr) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr[i] + 1;
                }

                return arr;
            };
            Func<int[], int[]> multiply = (arr) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr[i] * 2;
                }

                return arr;
            };
            Func<int[], int[]> subtract = (arr) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr[i] - 1;
                }

                return arr;
            };

            Func<int[], string> print = (arr) =>
            {
                return string.Join(" ", arr);
            };

            while (line != "end")
            {
                switch (line)
                {
                    case "add": numbers = add(numbers); break;
                    case "multiply": numbers = multiply(numbers); break;
                    case "subtract": numbers = subtract(numbers); break;
                    case "print": Console.WriteLine(print(numbers)); break;
                }

                line = Console.ReadLine();
            }
        }
    }
}
