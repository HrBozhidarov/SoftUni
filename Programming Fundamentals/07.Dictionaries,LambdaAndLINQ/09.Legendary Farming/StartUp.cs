namespace P09_LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var dicMaterialForItems = new Dictionary<string, int>();
            var dicJunkMaterials = new Dictionary<string, int>();
            var itemsDict = new Dictionary<string, string>();

            itemsDict["shards"] = "Shadowmourne";
            itemsDict["fragments"] = "Valanyr";
            itemsDict["motes"] = "Dragonwrath";

            dicMaterialForItems["shards"] = 0;
            dicMaterialForItems["fragments"] = 0;
            dicMaterialForItems["motes"] = 0;

            var isBreak = false;

            while (true)
            {
                var items = Console.ReadLine().ToLower().Split();

                for (int i = 0; i < items.Length; i += 2)
                {
                    var item = items[i + 1];
                    var valueOfItem = int.Parse(items[i]);

                    if (item == "shards")
                    {
                        dicMaterialForItems[item] += valueOfItem;
                    }
                    else if (item == "fragments")
                    {
                        dicMaterialForItems[item] += valueOfItem;
                    }
                    else if (item == "motes")
                    {
                        dicMaterialForItems[item] += valueOfItem;
                    }
                    else
                    {
                        if (!dicJunkMaterials.ContainsKey(item))
                        {
                            dicJunkMaterials[item] = 0;
                        }


                        dicJunkMaterials[item] += valueOfItem;
                    }

                    if (dicMaterialForItems.ContainsKey(item))
                    {
                        if (dicMaterialForItems[item] >= 250)
                        {
                            Console.WriteLine($"{itemsDict[item]} obtained!");
                            dicMaterialForItems[item] -= 250;
                            isBreak = true;
                            break;
                        }
                    }
                }

                if (isBreak)
                {
                    break;
                }
            }

            foreach (var item in dicMaterialForItems.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in dicJunkMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}