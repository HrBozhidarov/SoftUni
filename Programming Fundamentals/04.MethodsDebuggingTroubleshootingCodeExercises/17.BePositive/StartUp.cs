using System;
using System.Collections.Generic;

namespace P17_BePositive_broken
{
    public class BePositive_broken
    {
        public static void Main()
        {
            var countSequences = int.Parse(Console.ReadLine());

            for (int i = 0; i < countSequences; i++)
            {
                var input = Console.ReadLine().Trim().Split(' ');
                var numbers = new List<int>();

                for (int j = 0; j < input.Length; j++)
                {
                    if (!input[j].Equals(string.Empty))
                    {
                        var num = int.Parse(input[j]);
                        numbers.Add(num);
                    }
                }

                var found = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    var currentNum = numbers[j];

                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(currentNum);

                        found = true;
                    }
                    else
                    {
                        if (j < numbers.Count - 1)
                        {
                            currentNum += numbers[j + 1];
                        }

                        j++;

                        if (currentNum >= 0)
                        {
                            if (found)
                            {
                                Console.Write(" ");
                            }

                            Console.Write(currentNum);

                            found = true;
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine("(empty)");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}