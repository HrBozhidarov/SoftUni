namespace _03._02.SearchForNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var found = false;
            for (int i = elements[1]; i < elements[0]; i++)
            {
                if (numbers[i] == elements[2])
                {
                    Console.WriteLine("YES!");
                    found = true;
                    break;
                }
            }
            if (!found)
                Console.WriteLine("NO!");
        }
    }
}
