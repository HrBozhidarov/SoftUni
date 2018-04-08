namespace P06_UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, List<string>>();

            var text = string.Empty;

            while ((text = Console.ReadLine()) != "end")
            {
                var splitText = text.Split(' ');
                var ip = splitText[0];
                var user = splitText[2];

                if (!dic.ContainsKey(user))
                {
                    dic[user] = new List<string>();
                }

                dic[user].Add(ip);
            }

            foreach (var item in dic.OrderBy(x => x.Key))
            {
                var dictionary = new Dictionary<string, int>();

                for (int i = 0; i < item.Value.Count; i++)
                {
                    var currentValue = item.Value[i];
                    if (!dictionary.ContainsKey(currentValue))
                    {
                        dictionary[currentValue] = 0;
                    }

                    dictionary[currentValue]++;
                }

                var resultNameUser = item.Key.Split('=')[1];
                Console.WriteLine($"{resultNameUser}:");

                var result = string.Empty;

                foreach (var res in dictionary)
                {
                    var name = res.Key.Split('=')[1];
                    result += $"{name} => {res.Value}, ";
                }

                result = result.Substring(0, result.Length - 2) + ".";

                Console.WriteLine(result);
            }
        }
    }
}