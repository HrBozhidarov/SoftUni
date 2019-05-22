using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new string[dimensions[0], dimensions[1]];
            var snake = Console.ReadLine();
            var count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (count == snake.Length)
                    {
                        count = 0;
                    }

                    matrix[i, j] = snake[count].ToString();

                    count++;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var currentLine = new List<string>();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    currentLine.Add(matrix[i, j]);
                }

                Console.WriteLine(string.Join("", currentLine));
            }
        }
    }
}
