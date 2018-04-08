namespace P10_CubeProperties
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var cubeSide = double.Parse(Console.ReadLine());
            var shape = Console.ReadLine();

            Console.WriteLine("{0:f2}", GetCubeProperties(cubeSide, shape));
        }

        public static double GetCubeProperties(double cubeSide, string shape)
        {
            var result = 0.0;

            if (shape == "face")
            {
                result = Math.Sqrt(Math.Pow(cubeSide, 2) + Math.Pow(cubeSide, 2));
            }
            else if (shape == "space")
            {
                result = Math.Sqrt(Math.Pow(cubeSide, 2) + Math.Pow(cubeSide, 2) + Math.Pow(cubeSide, 2));
            }
            else if (shape == "volume")
            {
                result = Math.Pow(cubeSide, 3);
            }
            else if (shape == "area")
            {
                var area = cubeSide * cubeSide;

                result = 6 * area;
            }

            return result;
        }
    }
}
