using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Dictionary<string, long>> bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < items.Length; i += 2)
            {
                string item = items[i];
                long amount = long.Parse(items[i + 1]);
                string gem = string.Empty;

                if (item.Length == 3)
                {
                    gem = "Cash";
                }
                else if (item.ToLower().EndsWith("gem"))
                {
                    gem = "Gem";
                }
                else if (item.ToLower() == "gold")
                {
                    gem = "Gold";
                }

                if (gem == "")
                {
                    continue;
                }
                else if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
                {
                    continue;
                }

                switch (gem)
                {
                    case "Gem":
                        if (!bag.ContainsKey(gem))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (amount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[gem].Values.Sum() + amount > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(gem))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (amount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[gem].Values.Sum() + amount > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(gem))
                {
                    bag[gem] = new Dictionary<string, long>();
                }

                if (!bag[gem].ContainsKey(item))
                {
                    bag[gem][item] = 0;
                }

                bag[gem][item] += amount;

                if (gem == "Gold")
                {
                    gold += amount;
                }
                else if (gem == "Gem")
                {
                    gems += amount;
                }
                else if (gem == "Cash")
                {
                    cash += amount;
                }
            }

            foreach (var keyValuePair in bag)
            {
                Console.WriteLine($"<{keyValuePair.Key}> ${keyValuePair.Value.Values.Sum()}");
                foreach (var item2 in keyValuePair.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}