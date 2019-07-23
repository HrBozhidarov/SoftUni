using System;
using System.Collections.Generic;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfVehicles = new List<Vehicle>();
            var carCharacteristics = Console.ReadLine().Split();
            var truckCharacteristics = Console.ReadLine().Split();

            listOfVehicles.Add(new Car(double.Parse(carCharacteristics[1]), double.Parse(carCharacteristics[2])));
            listOfVehicles.Add(new Truck(double.Parse(truckCharacteristics[1]), double.Parse(truckCharacteristics[2])));

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();

                if (line[0] == "Drive")
                {
                    if (line[1] == "Car")
                    {
                        Console.WriteLine(listOfVehicles[0].Drive(double.Parse(line[2])));
                    }
                    else
                    {
                        Console.WriteLine(listOfVehicles[1].Drive(double.Parse(line[2])));
                    }
                }
                else
                {
                    if (line[1] == "Car")
                    {
                        listOfVehicles[0].Refueled(double.Parse(line[2]));
                    }
                    else
                    {
                        listOfVehicles[1].Refueled(double.Parse(line[2]));
                    }
                }
            }

            foreach (var vehicle in listOfVehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
