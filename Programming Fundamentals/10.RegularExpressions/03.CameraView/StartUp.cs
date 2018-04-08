using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main(string[] args)
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var input = Console.ReadLine();

        var skip = numbers[0];
        var take = numbers[1];
        var pattern = @"\|<[a-zA-Z0-9 ]+";
        var regex = new Regex(pattern);
        var matches = regex.Matches(input);

        var result = new List<string>();

        foreach (Match match in matches)
        {
            var currentLine = match.ToString().Substring(2);
            var currentResult = "";

            if (skip >= currentLine.Length)
            {
                continue;
            }

            if (skip + take >= currentLine.Length)
            {
                currentResult = currentLine.Substring(skip);
            }
            else
            {
                currentResult = currentLine.Substring(skip, take);
            }

            result.Add(currentResult);
        }

        Console.WriteLine(string.Join(", ", result));
    }
}