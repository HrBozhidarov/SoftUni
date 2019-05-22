using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine());
            var stack = new Stack<double>();

            for (double i = 0; i < n; i++)
            {
                var splitInput = Console.ReadLine().Split().Select(double.Parse).ToArray();
                var command = splitInput[0];

                switch (command)
                {
                    case 1: stack.Push(splitInput[1]); break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }

            var result = stack.Count > 0 ? string.Join(", ", stack) : "";
            Console.WriteLine(result);
        }
    }
}