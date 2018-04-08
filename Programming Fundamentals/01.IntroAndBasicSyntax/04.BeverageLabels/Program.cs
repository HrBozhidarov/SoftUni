using System;

namespace P04_BeverageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            var productName = Console.ReadLine();
            var volumeInMl = int.Parse(Console.ReadLine());
            var energyContentInKcl = int.Parse(Console.ReadLine());
            var shugarContentInG = int.Parse(Console.ReadLine());

            var volumeInL = volumeInMl / 100.0;

            Console.WriteLine($"{volumeInMl}ml {productName}:");
            Console.WriteLine($"{volumeInL * energyContentInKcl}kcal, {volumeInL * shugarContentInG}g sugars");

        }
    }
}
