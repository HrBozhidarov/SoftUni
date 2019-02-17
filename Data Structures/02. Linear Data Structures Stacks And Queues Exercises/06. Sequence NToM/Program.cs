using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sequence_NToM
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = nums[0];
            var m = nums[1];

            var queue = new Queue<Item>();
            queue.Enqueue(new Item(n, null));
            var result = new List<int>();

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                if (item.Number < m)
                {
                    queue.Enqueue(new Item(item.Number + 1, item));
                    queue.Enqueue(new Item(item.Number + 2, item));
                    queue.Enqueue(new Item(item.Number * 2, item));
                }

                if (item.Number == m)
                {
                    var currentItem = item;

                    while (currentItem != null)
                    {
                        result.Add(currentItem.Number);

                        currentItem = currentItem.Previous;
                    }

                    break;
                }
            }
                result.Reverse();

                Console.WriteLine(string.Join(" -> ", result));
        }
    }

    class Item
    {
        public Item(int number, Item previous)
        {
            this.Number = number;
            this.Previous = previous;
        }

        public Item Previous { get; set; }

        public int Number { get; set; }
    }
}
