using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var command = line[0];

                if (command == "1")
                {
                    var text = line[1];

                    if (stack.Count > 0)
                    {
                        var newText = stack.Peek() + text;
                        stack.Push(newText);
                    }
                    else
                    {
                        stack.Push(text);
                    }
                }
                else if (command == "2")
                {
                    var peak = stack.Peek();
                    var eraseCoun = int.Parse(line[1]);
                    var newText = peak.Substring(0, peak.Length - eraseCoun);

                    stack.Push(newText);
                }
                else if (command == "3")
                {
                    var index = int.Parse(line[1]);

                    var character = stack.Peek()[index - 1];

                    Console.WriteLine(character);
                }
                else
                {
                    stack.Pop();
                }
            }
        }
    }
}
