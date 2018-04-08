namespace P08_CenterPoint
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            ClosestToCenter(x1, y1, x2, y2);
        }

        public static void ClosestToCenter(double x1, double y1, double x2, double y2)
        {
            var firstPoint = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            var secondPoint = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            if (firstPoint <= secondPoint)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
