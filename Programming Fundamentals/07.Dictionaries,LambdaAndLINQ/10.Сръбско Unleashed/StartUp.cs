namespace P10_СръбскоUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class StartUp
    {
        static void Main(string[] args)
        {
            var text = string.Empty;
            var dic = new Dictionary<string, Dictionary<string, BigInteger>>();

            while ((text = Console.ReadLine()) != "End")
            {
                var splitTextOnTwo = text.Split('@');
                var nameOfSingers = string.Empty;
                var vanue = string.Empty;
                var money = 0l;


                var splitAnotherValues = splitTextOnTwo[1].Split();

                try
                {
                    money += (long.Parse(splitAnotherValues[splitAnotherValues.Length - 1])) * (long.Parse(splitAnotherValues[splitAnotherValues.Length - 2]));
                }
                catch
                {
                    continue;
                }

                for (int i = 0; i < splitAnotherValues.Length - 2; i++)
                {
                    var currentLine = splitAnotherValues[i];
                    vanue += currentLine + " ";
                }

                if (splitTextOnTwo[0][splitTextOnTwo[0].Length - 1] != ' ')
                {
                    continue;
                }

                vanue = vanue.Trim();
                nameOfSingers = splitTextOnTwo[0].Trim();

                if (!dic.ContainsKey(vanue))
                {
                    dic[vanue] = new Dictionary<string, BigInteger>();
                    dic[vanue][nameOfSingers] = 0;
                }

                if (!dic[vanue].ContainsKey(nameOfSingers))
                {
                    dic[vanue][nameOfSingers] = 0;
                }

                dic[vanue][nameOfSingers] += money;
            }

            foreach (var dictionary in dic)
            {
                Console.WriteLine(dictionary.Key);

                foreach (var dicSinger in dictionary.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {dicSinger.Key} -> {dicSinger.Value}");
                }
            }
        }
    }
}