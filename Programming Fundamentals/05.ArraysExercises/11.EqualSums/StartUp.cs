namespace P11_EqualSums
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var leftSum = 0;
            var rightSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                leftSum += numbers[i];
                rightSum = 0;

                for (int j = i + 2; j < numbers.Length; j++)
                {
                    rightSum += numbers[j];
                }
                if (leftSum == rightSum)
                {
                    int index = i + 1;

                    Console.WriteLine(index);

                    return;
                }
            }

            rightSum = 0;

            for (int i = 1; i <numbers.Length; i++)
            {
                rightSum += numbers[i];
            }

            if (rightSum==0)
            {
                Console.WriteLine(0);

                return;
            }

            Console.WriteLine("no");
        }
    }
}
