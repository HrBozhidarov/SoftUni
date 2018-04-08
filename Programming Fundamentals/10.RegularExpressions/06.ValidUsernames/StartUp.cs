using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main(string[] args)
    {
        var names = Console.ReadLine().Split(new char[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

        var pattern = @"^[a-zA-Z]\w{1,24}[^_]$";
        var regex = new Regex(pattern);
        var matches = new List<string>();

        foreach (var name in names)
        {
            if (regex.IsMatch(name))
            {
                matches.Add(name);
            }
        }

        var result = new List<string>();
        var sumOfTwoCouples = 0;

        for (int i = 0; i < matches.Count - 1; i++)
        {
            var sum = matches[i].Length + matches[i + 1].Length;

            if (sum > sumOfTwoCouples)
            {
                result.Clear();
                result.Add(matches[i]);
                result.Add(matches[i + 1]);
                sumOfTwoCouples = sum;
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, result));
    }
}
