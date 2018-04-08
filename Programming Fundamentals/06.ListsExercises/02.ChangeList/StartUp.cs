namespace P02_ChangeList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var comand = Console.ReadLine().Split().ToArray();

            while (comand[0] != "Odd" && comand[0] != "Even")
            {
                int element = int.Parse(comand[1]);

                if (comand[0] == "Delete")
                {
                    numbers.RemoveAll(a => a == element);
                }
                else if (comand[0] == "Insert")
                {
                    int index = int.Parse(comand[2]);
                    numbers.Insert(index, element);
                }

                comand = Console.ReadLine().Split().ToArray();
            }

            if (comand[0] == "Even")
            {
                foreach (var item in numbers)
                {
                    if (item % 2 == 0)
                    {
                        Console.Write($"{item} ");
                    }
                }
            }
            else if (comand[0] == "Odd")
            {
                foreach (var item in numbers)
                {
                    if (item % 2 != 0)
                    {
                        Console.Write($"{item} ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
