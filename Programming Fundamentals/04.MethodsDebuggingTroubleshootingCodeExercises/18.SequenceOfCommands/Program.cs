using System;
using System.Linq;
namespace P18_SequenceOfCommands_broken
{
    public class SequenceOfCommands_broken
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            var countOfNumbers = int.Parse(Console.ReadLine());

            var array = Console.ReadLine().Split(ArgumentsDelimiter).Select(long.Parse).ToArray();

            var command = Console.ReadLine().Trim().Split(' ');

            while (!command[0].Equals("stop"))
            {

                var args = new int[2];

                if (command[0].Equals("add") || command[0].Equals("subtract") || command[0].Equals("multiply"))
                {
                    args[0] = int.Parse(command[1]);
                    args[1] = int.Parse(command[2]);

                    PerformAction(array, command[0], args);
                }
                else if (command[0].Equals("rshift"))
                {
                    ArrayShiftRight(array);
                }
                else if (command[0].Equals("lshift"))
                {
                    ArrayShiftLeft(array);
                }

                PrintArray(array);

                Console.WriteLine();

                command = Console.ReadLine().Trim().Split(' ');
            }
        }

        private static void PerformAction(long[] array, string action, int[] args)
        {
           
            var pos = args[0] - 1;
            var value = args[1];

            switch (action)
            {
                case "multiply": array[pos] *= value; break;
                case "add": array[pos] += value; break;
                case "subtract": array[pos] -= value; break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            var newarr = array.Last();
            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = newarr;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            var newarr = array[0];

            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[array.Length - 1] = newarr;
        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}