using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        while (input != "END")
        {
            var separate = input.Split('&');

            var result = new Dictionary<string, List<string>>();

            foreach (var fildAndValue in separate)
            {
                var pattern = @"http.+?\?";

                var regex = new Regex(pattern);

                var clear = regex.Replace(fildAndValue, "");

                var separateFildFromValue = clear.Split('=');

                var fild = separateFildFromValue[0]
                    .Replace("+", string.Empty)
                    .Replace("%20", string.Empty).Trim();

                var values = separateFildFromValue[1]
                    .Replace("+", " ")
                    .Replace("%20", " ")
                    .Trim()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var value = string.Join(" ", values);

                if (!result.ContainsKey(fild))
                {
                    result[fild] = new List<string>();
                }

                result[fild].Add(value);
            }

            foreach (var item in result)
            {
                Console.Write($"{item.Key}=[{string.Join(", ", item.Value)}]");
            }

            Console.WriteLine();

            input = Console.ReadLine();
        }
    }
}
