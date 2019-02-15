using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_and_Average
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var sequences = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                Console.WriteLine($"Sum={sequences.Sum()}; Average={sequences.Average().ToString("F2")}");
            }
            catch 
            {
                Console.WriteLine($"Sum=0; Average=0.00");
            }
        }
    }
}
