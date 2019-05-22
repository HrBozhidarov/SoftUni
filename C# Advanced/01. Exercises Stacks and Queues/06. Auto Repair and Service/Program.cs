using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var models = Console.ReadLine().Split();
            var line = Console.ReadLine();
            var waitingService = new Queue<string>(models);
            var endService = new Stack<string>();

            while (line != "End")
            {
                if (line == "Service")
                {
                    if (waitingService.Count > 0)
                    {
                        var currentModel = waitingService.Dequeue();
                        endService.Push(currentModel);

                        Console.WriteLine($"Vehicle {currentModel} got served.");
                    }
                }
                else if (line.StartsWith("CarInfo-"))
                {
                    var model = line.Split('-')[1];

                    if (waitingService.Count > 0 && waitingService.Contains(model))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else if (endService.Count > 0 && endService.Contains(model)) 
                    {
                        Console.WriteLine("Served.");
                    }

                }
                else if (line == "History")
                {
                    if (endService.Count > 0)
                    {
                        Console.WriteLine(string.Join(", ", endService));
                    }
                }

                line = Console.ReadLine();
            }

            var waitingResult = waitingService.Count > 0 ? "Vehicles for service: " + string.Join(", ", waitingService) : "";
            var servedResult = endService.Count > 0 ? "Served vehicles: " + string.Join(", ", endService) : "";

            if (waitingResult != "")
            {
                Console.WriteLine(waitingResult);
            }

            Console.WriteLine(servedResult);
        }
    }
}
