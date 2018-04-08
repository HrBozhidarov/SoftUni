using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main(string[] args)
    {
        var line = "";
        var pattern = @"[A-Z]{2}\d+\.\d+[a-zA-Z]+\|";
        var patternNumber = @"\d+\.\d+";
        var dictionary = new Dictionary<string, KeyValuePair<double, string>>();

        while ((line = Console.ReadLine()) != "end")
        {
            var regex = new Regex(pattern);

            if (regex.IsMatch(line))
            {
                var temperature = new Regex(patternNumber).Match(line).ToString();
                var forecast = regex.Match(line).ToString();
                var city = forecast.Substring(0, 2);
                var indexStart = forecast.IndexOf(temperature) + temperature.Length;
                var typeOfWeather = forecast.Substring(indexStart, forecast.Length - 1 - indexStart);

                dictionary[city] = new KeyValuePair<double, string>(double.Parse(temperature), typeOfWeather);
            }
        }

        foreach (var item in dictionary.OrderBy(x => x.Value.Key))
        {
            Console.WriteLine($"{item.Key} => {item.Value.Key:F2} => {item.Value.Value}");
        }
    }
}
