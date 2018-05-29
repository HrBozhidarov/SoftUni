using System;
using System.Text.RegularExpressions;


namespace Exam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var input = "";
            var pattern = @"(1+)";
            var regex = new Regex(pattern);
            var sum = 0;
            var index = int.MaxValue;
            var length = 0;
            var result = "";
            var row = 1;
            var currentRow = 0;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                var splitInput = input.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
                var seq = string.Join("", splitInput);
                var currentSum = 0;
                var currentIndex = 0;
                var currentLength = 0;
                var find = "";
                currentRow++;

                var matches = regex.Matches(seq);

                foreach (Match match in matches)
                {
                    if (match.Length > currentLength)
                    {
                        currentLength = match.Length;
                        find = match.Groups[1].Value;
                    }

                    currentSum += match.Length;
                }

                currentIndex = seq.IndexOf(find);

                if (currentLength > length)
                {
                    index = currentIndex;
                    length = currentLength;
                    sum = currentSum;
                    result = seq;
                    row = currentRow;
                }
                else if (currentLength == length)
                {
                    if (currentIndex < index)
                    {
                        index = currentIndex;
                        length = currentLength;
                        sum = currentSum;
                        result = seq;
                        row = currentRow;
                    }
                    else if (currentIndex == index)
                    {
                        if (currentSum > sum)
                        {
                            index = currentIndex;
                            length = currentLength;
                            sum = currentSum;
                            result = seq;
                            row = currentRow;
                        }
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {row} with sum: {sum}.");
            foreach (var res in result)
            {
                Console.Write(res + " ");
            }

            Console.WriteLine();
        }
    }
}