using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                var parameters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = parameters[0];
                var power = int.Parse(parameters[1]);
                int? displacement = null;
                string efficiency = null;

                if (parameters.Length == 3)
                {
                    try
                    {
                        displacement = int.Parse(parameters[2]);
                    }
                    catch
                    {
                        efficiency = parameters[2];
                    }
                }
                else if (parameters.Length == 4)
                {
                    displacement = int.Parse(parameters[2]);
                    efficiency = parameters[3];
                }

                engines.Add(new Engine
                {
                    Model = model,
                    Power = power,
                    Displacement = displacement,
                    Efficiency = efficiency
                });
            }

            var m = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                var parameters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = parameters[0];
                var engineModel = parameters[1];
                int? weigth = null;
                string color = null;

                if (parameters.Length == 3)
                {
                    try
                    {
                        weigth = int.Parse(parameters[2]);
                    }
                    catch
                    {
                        color = parameters[2];
                    }
                   
                }
                else if (parameters.Length == 4)
                {
                    weigth = int.Parse(parameters[2]);
                    color = parameters[3];
                }

                var engine = engines.FirstOrDefault(x => x.Model == engineModel);

                cars.Add(new Car
                {
                    Model = model,
                    Engine = engine,
                    Weigth = weigth,
                    Color = color
                });
            }

            foreach (var car in cars)
            {
                var displacment = car.Engine.Displacement == null ? "n/a" : car.Engine.Displacement.ToString();
                var efficiency = car.Engine.Efficiency == null ? "n/a" : car.Engine.Efficiency;
                var carWeight = car.Weigth == null ? "n/a" : car.Weigth.ToString();
                var color = car.Color == null ? "n/a" : car.Color;
                var print = $"{car.Model}:\n";

                print += $"  {car.Engine.Model}:\n";
                print += $"    Power: {car.Engine.Power}\n";
                print += $"    Displacement: {displacment}\n";
                print += $"    Efficiency: {efficiency}\n";
                print += $"  Weight: {carWeight}\n";
                print += $"  Color: {color}";

                Console.WriteLine(print);
            }
        }
    }
}