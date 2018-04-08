using System;

namespace P09_CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;

            while (true)
            {
                try
                {
                    var num = int.Parse(Console.ReadLine());
                    count++;
                }
                catch
                {
                    break;
                }
            }
            Console.WriteLine(count);
        }
    }
}

