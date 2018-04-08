namespace P11_GeometryCalculator
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var figureType = Console.ReadLine().ToLower();

            if (figureType== "triangle")
            {
                var side = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                Console.WriteLine(CalculateTriangleArea(side,height));
            }
            else if (figureType == "square")
            {
                var side = double.Parse(Console.ReadLine());

                Console.WriteLine(CalculateSquareArea(side));
            }
            else if (figureType == "rectangle")
            {
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                Console.WriteLine(CalculateRectangleArea(width, height));
            }
            else if (figureType == "circle")
            {
                var radius = double.Parse(Console.ReadLine());

                Console.WriteLine(CalculateCircleArea(radius));
            }
        }

        public static double CalculateTriangleArea(double side, double height)
        {
            var area = Math.Round((side * height) / 2,2);

            return area;
        }

        public static double CalculateSquareArea(double side)
        {
            var area = Math.Round(side * side, 2);

            return area;
        }

        public static double CalculateRectangleArea(double width,double height)
        {
            var area = Math.Round(width * height, 2);

            return area; 
        }

        static double CalculateCircleArea(double radius)
        {
            var area = Math.Round(Math.PI * radius*radius,2);

            return area;
        }
    }
}
