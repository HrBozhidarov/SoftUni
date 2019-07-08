using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();

                var engine = new Engine
                {
                    EngineSpeed = int.Parse(line[1]),
                    EnginePower = int.Parse(line[2])
                };

                var cargo = new Cargo
                {
                    CargoWeigth = int.Parse(line[3]),
                    CargoType = line[4]
                };

                var tiresNames = line.Skip(5).ToArray();

                var collectionOfTires = new List<Tire>();

                for (int j = 0; j < tiresNames.Length; j += 2)
                {
                    collectionOfTires.Add(new Tire
                    {
                        TirePressure = double.Parse(tiresNames[j]),
                        TireAge = int.Parse(tiresNames[j + 1])
                    });
                }

                cars.Add(new Car(line[0], engine, cargo, collectionOfTires));
            }

            var command = Console.ReadLine();
            var resultCars = new List<Car>();

            if (command == "fragile")
            {
                resultCars = cars.Where(x => x.Cargo.CargoType == "fragile" && (x.Tires.Any(t => t.TirePressure < 1))).ToList();
            }
            else
            {
                resultCars = cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250).ToList();
            }

            Console.WriteLine(string.Join("\n", resultCars.Select(x => x.Model)));
        }
    }
}
