using System;
using System.Text.RegularExpressions;


class StartUp
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();
        var input = Console.ReadLine().Split(new[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

        var pattern = $"\\b{word}\\b";

        foreach (var item in input)
        {
            var regex = new Regex(pattern);

            if (regex.IsMatch(item))
            {
                Console.WriteLine(item.Trim());
            }
        }
    }
}
