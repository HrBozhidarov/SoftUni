namespace SomeNameSpace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dragons = new Dictionary<string, SortedDictionary<string, int[]>>();

            for (int i = 0; i < n; i++)
            {
                var characteristicsOfDragon = Console.ReadLine();

                var separateDragonsCharacteristics = characteristicsOfDragon.Split();

                var type = separateDragonsCharacteristics[0];
                var name = separateDragonsCharacteristics[1];
                var damage = int.Parse(separateDragonsCharacteristics[2] != "null" ? separateDragonsCharacteristics[2] : "45");
                var health = int.Parse(separateDragonsCharacteristics[3] != "null" ? separateDragonsCharacteristics[3] : "250");
                var armor = int.Parse(separateDragonsCharacteristics[4] != "null" ? separateDragonsCharacteristics[4] : "10");

                if (!dragons.ContainsKey(type))
                {
                    dragons[type] = new SortedDictionary<string, int[]>();
                }

                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type][name] = new int[] { damage, health, armor };
                }

                if (dragons.ContainsKey(type) && dragons[type].ContainsKey(name))
                {
                    dragons[type][name] = new int[] { damage, health, armor };
                }
            }

            foreach (var dragon in dragons)
            {
                var averageDamage = dragons[dragon.Key].Average(x => x.Value[0]);
                var averageHealth = dragons[dragon.Key].Average(x => x.Value[1]);
                var averageArmor = dragons[dragon.Key].Average(x => x.Value[2]);

                Console.WriteLine($"{dragon.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var drag in dragon.Value)
                {
                    Console.WriteLine($"-{drag.Key} -> damage: {drag.Value[0]}, health: {drag.Value[1]}, armor: {drag.Value[2]}");
                }
            }
        }
    }
}