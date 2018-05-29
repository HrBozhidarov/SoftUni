using System;
using System.Text.RegularExpressions;


namespace Exam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var pattern = @"([a-zA-Z]+)(.+)\1";
            var regex = new Regex(pattern);

            var input = Console.ReadLine();
            var plaseHolders = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            var matches = regex.Matches(input);

            var index = -1;

            foreach (Match match in matches)
            {
                index++;

                var currentMatch = match.Value;
                currentMatch = currentMatch.Replace(match.Groups[2].Value, plaseHolders[index]);

                input = input.Replace(match.Value, currentMatch);

                if (index >= plaseHolders.Length)
                {
                    index = 0;
                }
            }

            Console.WriteLine(input);
        }
    }
}