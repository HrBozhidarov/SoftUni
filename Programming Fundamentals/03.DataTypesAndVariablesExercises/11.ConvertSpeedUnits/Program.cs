namespace P11_ConvertSpeedUnits
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var meters = float.Parse(Console.ReadLine());
            var hours = float.Parse(Console.ReadLine());
            var minutes = float.Parse(Console.ReadLine());
            var second = float.Parse(Console.ReadLine());

            var convertToSeconds = ((hours * 60) * 60) + (minutes * 60) + second;
            var convertToHours = ((second / 60) / 60) + (minutes / 60) + hours;
            var metersToKm = (meters / 1000);
            var metersToMiles = (meters / 1609);

            Console.WriteLine(meters / convertToSeconds);

            Console.WriteLine(metersToKm / convertToHours);

            Console.WriteLine(metersToMiles / convertToHours);
        }
    }
}
