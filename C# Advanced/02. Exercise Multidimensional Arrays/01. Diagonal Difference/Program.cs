using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var inputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[i, col] = inputRow[col];
                }
            }

            var result = Math.Abs(FirstDiagonalSum(matrix) - SecondDiagonalSum(matrix));

            Console.WriteLine(result);
        }

        private static int FirstDiagonalSum(int[,] matrix)
        {
            var sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }

        private static int SecondDiagonalSum(int[,] matrix)
        {
            var sum = 0;
            var row = 0;

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                sum += matrix[row, i];

                row++;
            }

            return sum;
        }
    }
}
