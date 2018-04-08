namespace P03_FoldAndSumShortSolution
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var k = numbers.Length / 4;
            var leftArray = numbers.Take(k).ToArray();
            var rightArray = numbers.Skip(k*3).Take(k).ToArray();
            var middleArray = numbers.Skip(k).Take(k * 2).ToArray();

            Array.Reverse(leftArray);
            Array.Reverse(rightArray);

            var result = new int[k * 2];

            for (int i = 0; i < k; i++)
            {
                result[i] = leftArray[i] + middleArray[i];
                result[k+i] = rightArray[i] + middleArray[k+i];
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
