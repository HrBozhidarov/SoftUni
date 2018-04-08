namespace P05_ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var command = Console.ReadLine()
                .Split()
                .ToArray();

            while (command[0] != "print")
            {
                if (command[0] == "add")
                {
                    int index = int.Parse(command[1]);
                    int element = int.Parse(command[2]);
                    numbers.Insert(index, element);
                }
                else if (command[0] == "addMany")
                {
                    int index = int.Parse(command[1]);
                    numbers.InsertRange(index, command.Skip(2).Select(int.Parse).ToList());
                }
                if (command[0] == "contains")
                {
                    int element = int.Parse(command[1]);

                    Console.WriteLine(numbers.IndexOf(element));
                }
                if (command[0] == "remove")
                {
                    int index = int.Parse(command[1]);
                    numbers.RemoveAt(index);
                }
                if (command[0] == "shift")
                {
                    int index = int.Parse(command[1]);
                    for (int i = 0; i < index; i++)
                    {
                        int digit = numbers[0];
                        numbers.Remove(numbers[0]);
                        numbers.Add(digit);
                    }
                }
                if (command[0] == "sumPairs")
                {
                    for (int i = 0; i < numbers.Count - 1; i++)
                    {
                        numbers[i] += numbers[i + 1];
                        numbers.RemoveAt(i + 1);
                    }
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine($"[{(string.Join(", ", numbers))}]");
        }
    }
}
