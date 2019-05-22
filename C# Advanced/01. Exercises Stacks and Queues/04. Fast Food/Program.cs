using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var quantityOfFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();
            var biggestOrder = -1;

            foreach (var order in orders)
            {
                queue.Enqueue(order);
            }

            while (queue.Count > 0)
            {
                var currentOrder = queue.Peek();
                quantityOfFood -= currentOrder;

                if (currentOrder > biggestOrder)
                {
                    biggestOrder = currentOrder;
                }

                if (quantityOfFood < 0)
                {
                    Console.WriteLine(biggestOrder);
                    Console.WriteLine("Orders left: " + string.Join(" ", queue));
                    return;
                }

                queue.Dequeue();
            }

            Console.WriteLine(biggestOrder);
            Console.WriteLine("Orders complete");
        }
    }
}
