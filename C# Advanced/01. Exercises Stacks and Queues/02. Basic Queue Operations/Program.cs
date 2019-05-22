using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int enqueueCount = input[0];
            int dequeueCount = input[1];
            int element = input[2];

            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < enqueueCount; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < dequeueCount; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}