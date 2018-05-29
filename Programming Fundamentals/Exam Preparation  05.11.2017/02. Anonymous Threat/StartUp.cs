using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamSoftUni
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var seq = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var input = "";

            while ((input = Console.ReadLine()) != "3:1")
            {
                var splitInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = splitInput[0];


                if (command == "merge")
                {
                    var startIndex = int.Parse(splitInput[1]);
                    var endIndex = int.Parse(splitInput[2]);

                    if (endIndex < 0 || startIndex >= seq.Count - 1)
                    {
                        continue;
                    }

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    seq = Merge(startIndex, endIndex, seq);
                }
                else
                {
                    var index = int.Parse(splitInput[1]);
                    var partions = int.Parse(splitInput[2]);

                    seq = Divide(index, partions, seq);
                }
            }

            Console.WriteLine(string.Join(" ", seq));
        }

        private static List<string> Divide(int index, int partions, List<string> seq)
        {
            var divide = seq[index].Length / partions;
            var str = seq[index];
            var list = new List<string>();

            for (int i = 0; i < partions - 1; i++)
            {
                var currentDivide = str.Substring(0, divide);
                list.Add(currentDivide);
                str = str.Remove(0, divide);
            }

            if (str.Length > 0)
            {
                list.Add(str);
            }

            seq.RemoveAt(index);
            seq.InsertRange(index, list);

            return seq;
        }

        private static List<string> Merge(int startIndex, int endIndex, List<string> seq)
        {
            var list = new List<string>();
            var message = "";

            message = string.Join("", seq.Skip(startIndex).Take(endIndex - startIndex + 1).ToList());

            if (startIndex > 0)
            {
                for (int i = 0; i < startIndex; i++)
                {
                    list.Add(seq[i]);
                }
            }

            list.Add(message);

            if (endIndex < seq.Count - 1)
            {
                for (int i = endIndex + 1; i < seq.Count; i++)
                {
                    list.Add(seq[i]);
                }
            }

            return list;
        }
    }
}