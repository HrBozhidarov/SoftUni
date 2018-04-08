namespace P09_LongerLine
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var pointOneX1 = double.Parse(Console.ReadLine());
            var pointOneY1= double.Parse(Console.ReadLine());
            var pointOneX2 = double.Parse(Console.ReadLine());
            var pointOneY2 = double.Parse(Console.ReadLine());

            var pointTwoX1 = double.Parse(Console.ReadLine());
            var pointTwoY1 = double.Parse(Console.ReadLine());
            var pointTwoX2 = double.Parse(Console.ReadLine());
            var pointTwoY2 = double.Parse(Console.ReadLine());

            var first = GetLineSize(pointOneX1, pointOneY1, pointOneX2, pointOneY2);
            var second = GetLineSize(pointTwoX1, pointTwoY1, pointTwoX2, pointTwoY2);

            if (first>=second)
            {
                ClosestToZero(pointOneX1, pointOneY1, pointOneX2, pointOneY2);
            }
            else
            {
                ClosestToZero(pointTwoX1, pointTwoY1, pointTwoX2, pointTwoY2);
            }
        }

        public static double GetLineSize(double x1,double y1, double x2, double y2)
        {
            double sum = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            return sum;
        }
        
        public static void ClosestToZero(double x1, double y1, double x2, double y2)
        {
            var firstPoint = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            var secondPoint = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            if (firstPoint <= secondPoint)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }
    }
}
