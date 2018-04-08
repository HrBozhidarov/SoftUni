namespace P16_ComparingFloats
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var fistNumber = double.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());

            var biggerNum = Math.Max(fistNumber, secondNumber);
            var smallerNum = Math.Min(fistNumber, secondNumber);
            var result = biggerNum - smallerNum;

            if (result < 0.000001)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
