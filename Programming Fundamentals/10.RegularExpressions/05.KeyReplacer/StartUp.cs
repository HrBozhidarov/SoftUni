using System;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main(string[] args)
    {
        var startAndEnd = Console.ReadLine();
        var input = Console.ReadLine();

        var start = "";
        var end = "";


        for (int i = 0; i < startAndEnd.Length; i++)
        {
            var currentSymbol = startAndEnd[i];

            if (currentSymbol == '<' || currentSymbol == '|' || currentSymbol == '\\')
            {
                break;
            }
            else
            {
                start += currentSymbol;
            }
        }

        for (int i = startAndEnd.Length - 1; i >= 0; i--)
        {
            var currentSymbol = startAndEnd[i];

            if (currentSymbol == '<' || currentSymbol == '|' || currentSymbol == '\\')
            {
                break;
            }
            else
            {
                end = currentSymbol + end;
            }
        }

        var pattern = start + $"[^{start}|{end}]" + @"[a-zA-Z]+?" + end;
        var regex = new Regex(pattern);
        var matches = regex.Matches(input);

        var result = "";

        foreach (Match match in matches)
        {
            var line = match.ToString();

            var startIndex = line.IndexOf(start) + start.Length;

            result += line.Substring(startIndex, line.Length - startIndex - end.Length);
        }

        if (result == string.Empty)
        {
            Console.WriteLine("Empty result");
        }
        else
        {
            Console.WriteLine(result);
        }
    }
}