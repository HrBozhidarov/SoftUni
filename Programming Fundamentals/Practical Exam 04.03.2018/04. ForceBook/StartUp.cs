using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, List<string>>();

            var input = "";

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                var isHave = input.IndexOf(" | ");


                if (isHave > 0)
                {
                    var splitInput = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                    var forceSide = splitInput[0];
                    var forceUser = splitInput[1];

                    var ifHave = false;

                    foreach (var item in dic)
                    {
                        if (item.Value.Contains(forceUser))
                        {
                            ifHave = true;
                            break;
                        }
                    }

                    if (!ifHave)
                    {
                        if (!dic.ContainsKey(forceSide))
                        {
                            dic[forceSide] = new List<string>();
                        }

                        dic[forceSide].Add(forceUser);
                    }
                }
                else
                {
                    var splitInput = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    var forceSide = splitInput[1];
                    var forceUser = splitInput[0];

                    foreach (var item in dic)
                    {
                        if (item.Value.Contains(forceUser))
                        {
                            item.Value.Remove(forceUser);
                            break;
                        }
                    }

                    if (!dic.ContainsKey(forceSide))
                    {
                        dic[forceSide] = new List<string>();
                    }

                    dic[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            foreach (var item in dic.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (item.Value.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                foreach (var res in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {res}");
                }
            }
        }
    }
}