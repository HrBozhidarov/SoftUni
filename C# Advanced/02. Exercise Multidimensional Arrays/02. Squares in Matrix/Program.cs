using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstDimensionSize = dimensions[0];
            var secondDimensionSize = dimensions[1];
            var jaddgeArr = new string[firstDimensionSize][];
            var count = 0;

            if (firstDimensionSize > 1 && secondDimensionSize > 1)
            {
                for (int i = 0; i < jaddgeArr.Length; i++)
                {
                    var inputCharacters = Console.ReadLine().Split();

                    jaddgeArr[i] = inputCharacters;
                }

                for (int i = 0; i < jaddgeArr.Length - 1; i++)
                {
                    for (int j = 0; j < jaddgeArr[i].Length - 1; j++)
                    {
                        var character = jaddgeArr[i][j];

                        if (CheckIfHaveSquareFromEqualCharacters(i, j, jaddgeArr, character))
                        {
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static bool CheckIfHaveSquareFromEqualCharacters(int i, int j, string[][] jaddgeArr, string character)
        {
            return jaddgeArr[i][j] == character && jaddgeArr[i][j + 1] == character && jaddgeArr[i + 1][j] == character && jaddgeArr[i + 1][j + 1] == character;
        }
    }
}
