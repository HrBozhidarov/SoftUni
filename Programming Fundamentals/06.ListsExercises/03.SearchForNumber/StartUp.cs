namespace P03_SearchForNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var takeElements = elements[0];
            var deleteElements = elements[1];
            var findNumber = elements[2];

            for (int i = 0, count=0;  i < deleteElements; i++)
            {
                numbers.RemoveAt(count);
            }

            var leftElements = takeElements - deleteElements;

            for (int i = 0; i < leftElements; i++)
            {
                if (numbers[i] == findNumber)
                {
                    Console.WriteLine("YES!");

                    return;
                }
            }

            Console.WriteLine("NO!");
        }
    }
}
