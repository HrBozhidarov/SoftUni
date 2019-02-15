using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sort_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split().OrderBy(x => x).ToList();

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
