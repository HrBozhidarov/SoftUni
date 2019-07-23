using System;

namespace _02.VehiclesExtension
{
    class Program
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(busInfo[0], double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();
                switch (args[1])
                {
                    case "Car":
                        MakeAction(car, args);
                        break;
                    case "Truck":
                        MakeAction(truck, args);
                        break;
                    case "Bus":
                        MakeAction(bus, args);
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void MakeAction(Vehicle vehicle, string[] args)
        {
            switch (args[0])
            {
                case "Drive":
                    BusFuelChecker(vehicle, args);
                    vehicle.Drive(double.Parse(args[2]));
                    break;
                case "DriveEmpty":
                    BusFuelChecker(vehicle, args);
                    vehicle.Drive(double.Parse(args[2]));
                    break;
                case "Refuel":
                    vehicle.Refuel(double.Parse(args[2]));
                    break;
            }
        }

        private static void BusFuelChecker(Vehicle vehicle, string[] args)
        {
            if (vehicle is Bus)
            {
                ((Bus)vehicle).NeededFuelForJourney(args[0]);
            }
        }
    }
}