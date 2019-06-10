using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var model = line[0];
                var fuelAmount = double.Parse(line[1]);
                var fuelConsumption = double.Parse(line[2]);

                cars.Add(new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumption
                });
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var splitCommand = command.Split();
                var carModel = splitCommand[1];
                var amountOfKm = double.Parse(splitCommand[2]);

                var car = cars.FirstOrDefault(x => x.Model == carModel);

                if (!car.Move(amountOfKm))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
