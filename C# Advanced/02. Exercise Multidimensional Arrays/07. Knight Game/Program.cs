using System;
using System.Linq;

namespace _07._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var deathNights = 0;

            for (int row = 0; row < n; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var currentRow = 0;
            var currentCol = 0;

            for (int i = 0; i < n * n; i++)
            {
                var ifHaveDeathKnight = false;
                var compareCount = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        var currentCount = DeathKnight(matrix, row, col);

                        if (matrix[row, col] == 'K' && currentCount > compareCount)
                        {
                            compareCount = currentCount;
                            currentRow = row;
                            currentCol = col;
                            ifHaveDeathKnight = true;
                        }
                    }
                }

                if (ifHaveDeathKnight)
                {
                    deathNights++;
                    matrix[currentRow, currentCol] = '0';
                }
            }

            Console.WriteLine(deathNights);
        }

        private static int DeathKnight(char[,] matrix, int row, int col)
        {
            var currentCount = 0;

            var leftUpDirection = col - 2 < 0 || row - 1 < 0 || matrix[row - 1, col - 2] != 'K';
            var leftDownDirection = col - 2 < 0 || row + 1 >= matrix.GetLength(0) || matrix[row + 1, col - 2] != 'K';
            var rightUpDirection = col + 2 >= matrix.GetLength(1) || row - 1 < 0 || matrix[row - 1, col + 2] != 'K';
            var rightDownDirection = col + 2 >= matrix.GetLength(1) || row + 1 >= matrix.GetLength(0) || matrix[row + 1, col + 2] != 'K';
            var downLeftDirection = col - 1 < 0 || row + 2 >= matrix.GetLength(1) || matrix[row + 2, col - 1] != 'K';
            var downRightDirection = col + 1 >= matrix.GetLength(1) || row + 2 >= matrix.GetLength(1) || matrix[row + 2, col + 1] != 'K';
            var upLeftDirection = col - 1 < 0 || row - 2 < 0 || matrix[row - 2, col - 1] != 'K';
            var upRightDirection = col + 1 >= matrix.GetLength(1) || row - 2 < 0 || matrix[row - 2, col + 1] != 'K';

            if (!leftUpDirection)
            {
                currentCount++;
            }

            if (!leftDownDirection)
            {
                currentCount++;
            }

            if (!rightUpDirection)
            {
                currentCount++;
            }

            if (!rightDownDirection)
            {
                currentCount++;
            }

            if (!downLeftDirection)
            {
                currentCount++;
            }

            if (!downRightDirection)
            {
                currentCount++;
            }

            if (!upLeftDirection)
            {
                currentCount++;
            }

            if (!upRightDirection)
            {
                currentCount++;
            }

            return currentCount;
        }
    }
}