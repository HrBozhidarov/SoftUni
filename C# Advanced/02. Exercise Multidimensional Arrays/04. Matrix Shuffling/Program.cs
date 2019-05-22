using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new string[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var data = Console.ReadLine().Split();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];
                }
            }

            var line = "";

            while ((line = Console.ReadLine()) != "END")
            {
                var lineSplit = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (lineSplit.Length != 5 && lineSplit[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");

                    continue;
                }

                var row1 = 0;
                var col1 = 0;
                var row2 = 0;
                var col2 = 0;

                try
                {
                    row1 = int.Parse(lineSplit[1]);
                    col1 = int.Parse(lineSplit[2]);
                    row2 = int.Parse(lineSplit[3]);
                    col2 = int.Parse(lineSplit[4]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");

                    continue;
                }


                if (!IfHaveCorrectCoordinate(row1, col1, row2, col2, matrix))
                {
                    Console.WriteLine("Invalid input!");

                    continue;
                }

                var firstValue = matrix[row1, col1];
                var secondValue = matrix[row2, col2];

                matrix[row1, col1] = secondValue;
                matrix[row2, col2] = firstValue;

                PrintMatrix(matrix);
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var pushElements = new List<string>();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    pushElements.Add(matrix[i, j]);
                }

                Console.WriteLine(string.Join(" ", pushElements));
            }
        }

        private static bool IfHaveCorrectCoordinate(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            var firstCoordinates = row1 >= 0 && row1 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1);
            var secondCoordinates = row2 >= 0 && row2 < matrix.GetLength(0) && col2 >= 0 && col2 < matrix.GetLength(1);

            return firstCoordinates && secondCoordinates;
        }
    }
}
