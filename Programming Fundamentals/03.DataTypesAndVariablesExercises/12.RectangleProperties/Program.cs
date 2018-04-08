namespace P12_RectangleProperties
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var area = width * height;
            var perim = (2 * width) + (2 * height);
            var diagonal1 = Math.Pow(width, 2);
            var diaglonal2 = Math.Pow(height, 2);
            var diagonal = diagonal1 + diaglonal2;

            Console.WriteLine(perim);

            Console.WriteLine(area);

            Console.WriteLine(Math.Sqrt(diagonal));
        }
    }
}
