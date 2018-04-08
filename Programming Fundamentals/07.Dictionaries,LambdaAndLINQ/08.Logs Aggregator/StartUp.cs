namespace P08_LogsAggregator
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dic = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var inforamtion = Console.ReadLine().Split();
                var ip = inforamtion[0];
                var user = inforamtion[1];
                var duration = int.Parse(inforamtion[2]);

                if (!dic.ContainsKey(user))
                {
                    dic[user] = new SortedDictionary<string, int>();
                }

                if (!dic[user].ContainsKey(ip))
                {
                    dic[user][ip] = duration;
                }
                else
                {
                    dic[user][ip] += duration;
                }
            }

            foreach (var item in dic)
            {
                var sum = 0;
                var ips = new List<string>();

                foreach (var item1 in item.Value)
                {
                    sum += item1.Value;
                    ips.Add(item1.Key);
                }

                Console.WriteLine($"{item.Key}: {sum} [{string.Join(", ", ips)}]");
            }
        }
    }
}