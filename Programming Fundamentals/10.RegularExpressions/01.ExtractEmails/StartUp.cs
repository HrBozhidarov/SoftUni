using System;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var pattern = @"[A-Za-z0-9_.-]+[\._-]*?[A-Za-z0-9]+@[a-zA-Z]+-*?[a-zA-Z]+(\.[A-Za-z]+)+";

        var regex = new Regex(pattern);

        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            var email = match.ToString();

            if (email[0] == '-' || email[0] == '_' || email[0] == '.')
            {
                continue;
            }

            Console.WriteLine(match);
        }
    }
}
