using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstDimension = dimensions[0];
            var secondDimension = dimensions[1];
            var matrix = new int[firstDimension][];
            var maxSum = int.MinValue;
            var resultMatrix = new int[3, 3];

            if (firstDimension > 2 && secondDimension > 2)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    matrix[i] = numbers;
                }

                for (int i = 0; i < matrix.Length - 2; i++)
                {
                    for (int j = 0; j < matrix[i].Length - 2; j++)
                    {
                        var compareMatrix = new int[3, 3];
                        var currentSum = GetSumFromRectangle(i, j, matrix, compareMatrix);

                        if (currentSum > maxSum)
                        {
                            resultMatrix = compareMatrix;
                            maxSum = currentSum;
                        }
                    }
                }

                Console.WriteLine("Sum = " + maxSum);

                for (int i = 0; i < resultMatrix.GetLength(0); i++)
                {
                    var currenResult = new int[3];

                    for (int j = 0; j < resultMatrix.GetLength(1); j++)
                    {
                        currenResult[j] = resultMatrix[i, j];
                    }

                    Console.WriteLine(string.Join(" ", currenResult));
                }
            }
            else
            {
                Console.WriteLine("Sum = 0");
            }
        }

        private static int GetSumFromRectangle(int currentFirstDimension, int currentSecondDimension, int[][] matrix, int[,] compareMatrix)
        {
            var sum = 0;
            var row = 0;

            for (int i = currentFirstDimension; i < currentFirstDimension + 3; i++)
            {
                var col = 0;
                for (int j = currentSecondDimension; j < currentSecondDimension + 3; j++)
                {
                    compareMatrix[row, col] = matrix[i][j];
                    sum += matrix[i][j];
                    col++;
                }

                row++;
            }

            return sum;
        }
    }
}
