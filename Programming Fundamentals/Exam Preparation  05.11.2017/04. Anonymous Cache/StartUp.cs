using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamSoftUni
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, List<string>>();
            var cash = new Dictionary<string, List<string>>();

            var input = "";

            while ((input = Console.ReadLine()) != "thetinggoesskrra")
            {
                var splitInput = input.Split(new char[] { '-', '>', '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (splitInput.Length == 1)
                {
                    if (!dic.ContainsKey(splitInput[0]))
                    {
                        dic[splitInput[0]] = new List<string>();
                    }

                    if (cash.ContainsKey(splitInput[0]))
                    {
                        foreach (var item in cash[splitInput[0]])
                        {
                            dic[splitInput[0]].Add(item);
                        }

                        cash.Remove(splitInput[0]);
                    }
                }
                else
                {
                    var dataKey = splitInput[0];
                    var dataSize = splitInput[1];
                    var dataSet = splitInput[2];
                    var value = dataKey + '-' + dataSize;

                    if (dic.ContainsKey(dataSet))
                    {
                        dic[dataSet].Add(value);
                    }
                    else
                    {
                        if (!cash.ContainsKey(dataSet))
                        {
                            cash[dataSet] = new List<string>();
                        }

                        cash[dataSet].Add(value);
                    }
                }
            }

            if (dic.Count == 0)
            {
                return;
            }

            foreach (var item in dic.OrderByDescending(x => x.Value.Sum(y => long.Parse(y.Split('-')[1]))))
            {

                Console.WriteLine($"Data Set: {item.Key}, Total Size: {item.Value.Sum(y => long.Parse(y.Split('-')[1]))}");

                foreach (var r in item.Value)
                {
                    Console.WriteLine($"$.{r.Split('-')[0]}");
                }

                break;
            }
        }
    }
}