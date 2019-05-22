using System;
using System.Linq;

namespace _6._Bomb_the_Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new int[dimension[0], dimension[1]];
            var bombParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var targetRow = bombParameters[0];
            var targetCol = bombParameters[1];
            var radius = bombParameters[2];

            FillMatrix(matrix, targetRow, targetCol, radius);
            ChangeMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void FillMatrix(int[,] matrix, int targetRow, int targetCol, int radius)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var part = Math.Pow(i - targetRow, 2) + Math.Pow(j - targetCol, 2);

                    if (part <= Math.Pow(radius, 2))
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void ChangeMatrix(int[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                var count = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        matrix[row, col] = 0;
                        count++;
                    }
                }

                for (int row = 0; row < count; row++)
                {
                    matrix[row, col] = 1;
                }
            }
        }
    }
}
