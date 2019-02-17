using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Calculate_Sequence_with_a_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialNumber = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var result = new List<long>();

            queue.Enqueue(initialNumber);

            while (result.Count < 50)
            {
                var s = queue.Dequeue();
                result.Add(s);

                queue.Enqueue(s + 1);
                queue.Enqueue((2 * s) + 1);
                queue.Enqueue(s + 2);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
