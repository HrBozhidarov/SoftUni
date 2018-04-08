namespace P03_FoldAndSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().ToArray();
            var leftSide = new int[input.Length / 4];
            var rightSide = new int[input.Length / 4];
            var middlePart = new int[input.Length / 2];

            FillLeftSideOfArray(leftSide, input);
            FillRightSideOfArray(rightSide, input);
            FillMiddlePartOfArray(input, middlePart, leftSide);

            var bothLeftAndRightSide = new int[input.Length / 2];

            ConnectBothSidesReversed(leftSide, rightSide, input, bothLeftAndRightSide);

            var sum = new int[input.Length / 2];

            for (int i = 0; i < input.Length / 2; i++)
            {
                sum[i] = middlePart[i] + bothLeftAndRightSide[i];
            }

            Console.WriteLine(string.Join(" ", sum));
        }

        static void FillLeftSideOfArray(int[] leftSide, string[] input)
        {
            for (int i = 0; i < leftSide.Length; i++)
            {
                leftSide[i] = int.Parse(input[i]);
            }
        }

        static void FillRightSideOfArray(int[] rightSide, string[] input)
        {
            for (int i = 0; i < rightSide.Length; i++)
            {
                rightSide[i] = int.Parse(input[input.Length - rightSide.Length + i]);
            }
        }

        static void FillMiddlePartOfArray(string[] input, int[] middlePart, int[] leftSide)
        {
            for (int i = 0; i < middlePart.Length; i++)
            {
                middlePart[i] = int.Parse(input[input.Length - leftSide.Length - middlePart.Length + i]);
            }
        }

        static void ConnectBothSidesReversed(int[] leftSide, int[] rightSide, string[] input, int[] bothLeftAndRightSide)
        {
            for (int i = leftSide.Length - 1, count = 0; i >= 0; i--)
            {
                bothLeftAndRightSide[count] = leftSide[i];
                count++;
            }

            for (int i = leftSide.Length - 1, count = 0; i >= 0; i--)
            {
                bothLeftAndRightSide[leftSide.Length + count] = rightSide[i];
                count++;
            }
        }
    }
}
