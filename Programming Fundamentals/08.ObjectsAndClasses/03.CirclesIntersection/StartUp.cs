using System;
using System.Linq;

internal class StartUp
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Circle
    {
        public Circle(Point center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public Point Center { get; set; }
        public double Radius { get; set; }
    }

    public static void Main()
    {
        var firstParameters = Console.ReadLine().Split().Select(double.Parse).ToArray();
        var secondParameters = Console.ReadLine().Split().Select(double.Parse).ToArray();

        var firstPoint = new Point();
        firstPoint.X = firstParameters[0];
        firstPoint.Y = firstParameters[1];

        var secondPoint = new Point();
        secondPoint.X = secondParameters[0];
        secondPoint.Y = secondParameters[1];

        var firstCircle = new Circle(firstPoint, firstParameters[2]);
        var secondCircle = new Circle(secondPoint, secondParameters[2]);

        if (IsIntersect(firstCircle, secondCircle))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }

    public static bool IsIntersect(Circle first, Circle second)
    {
        var distance = Math.Sqrt(Math.Pow((first.Center.X - second.Center.X), 2) + Math.Pow(first.Center.Y - second.Center.Y, 2));

        if (distance <= first.Radius + second.Radius)
        {
            return true;
        }

        return false;
    }
}