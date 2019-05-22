using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(line);
            }

            var index = 0;

            while (true)
            {
                var petrol = 0;

                foreach (var parameters in queue)
                {
                    var fuel = parameters[0];
                    var distanceToPetrolStation = parameters[1];
                    petrol += parameters[0] - distanceToPetrolStation;

                    if (petrol < 0)
                    {
                        queue.Enqueue(queue.Dequeue());
                        index++;
                        break;
                    }
                }

                if (petrol >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}