using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" -> ");
                var color = line[0];
                var clothes = line[1].Split(',');

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var clothe in clothes)
                {
                    if (!wardrobe[color].ContainsKey(clothe))
                    {
                        wardrobe[color][clothe] = 0;
                    }

                    wardrobe[color][clothe]++;
                }
            }

            var search = Console.ReadLine().Split();
            var serachColor = search[0];
            var serachClothe = search[1];

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var dic in wardrobe[kvp.Key])
                {
                    if (kvp.Key == serachColor && dic.Key == serachClothe)
                    {
                        Console.WriteLine($"* {dic.Key} - {dic.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {dic.Key} - {dic.Value}");
                    }
                }
            }
        }
    }
}
