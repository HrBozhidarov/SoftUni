using System;

namespace P11_5DifferentNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            var count = 0;

            for (int first = start; first < end; first++)
            {
                for (int second = start; second < end; second++)
                {
                    for (int third = start; third < end; third++)
                    {
                        for (int fourth = start; fourth < end; fourth++)
                        {
                            for (int fifth = start; fifth <= end; fifth++)
                            {
                                if (start <= first && first < second && second < third && third < fourth && fourth < fifth && fifth <= end)
                                {
                                    Console.WriteLine($"{first} {second} {third} {fourth} {fifth}");
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
