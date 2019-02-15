using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Remove_Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                var currentNumber = list[i];
                var currentCount = 0;

                for (int j = 0; j < list.Count; j++)
                {
                    if (currentNumber == list[j])
                    {
                        currentCount++;
                    }
                }

                if (currentCount % 2 == 1)
                {
                    list.RemoveAll(x => x == currentNumber);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}