namespace P07_PopilationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, Dictionary<string, long>>();

            var text = string.Empty;

            while ((text = Console.ReadLine()) != "report")
            {
                var splitText = text.Split('|');

                var country = splitText[1];
                var nameOfCity = splitText[0];
                var population = int.Parse(splitText[2]);

                if (!dic.ContainsKey(country))
                {
                    dic[country] = new Dictionary<string, long>();
                }

                if (!dic[country].ContainsKey(nameOfCity))
                {
                    dic[country].Add(nameOfCity, 0);
                }

                dic[country][nameOfCity] += population;
            }

            var sortetDictionary = dic.OrderByDescending(d => d.Value.Values.Sum()).ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in sortetDictionary)
            {
                var result = 0l;

                foreach (var item2 in item.Value)
                {
                    result += item2.Value;
                }

                Console.WriteLine($"{item.Key} (total population: {result})");

                foreach (var item1 in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{item1.Key}: {item1.Value}");
                }
            }
        }
    }
}