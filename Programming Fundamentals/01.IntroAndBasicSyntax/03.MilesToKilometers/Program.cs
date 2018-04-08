using System;

namespace P03_MilesToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            const double mileInKilometer = 1.60934;

            var miles = double.Parse(Console.ReadLine());

            var convertMilesToKilometers = miles * mileInKilometer;

            Console.WriteLine($"{convertMilesToKilometers:F2}");
        }
    }
}
