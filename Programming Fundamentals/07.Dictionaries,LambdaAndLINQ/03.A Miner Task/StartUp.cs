namespace P03_AMinerTask
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var text = string.Empty;
            var dic = new Dictionary<string, int>();
            int count = 1;
            var previosText = string.Empty;

            while ((text = Console.ReadLine()) != "stop")
            {
                if (count % 2 == 1)
                {
                    if (!dic.ContainsKey(text))
                    {
                        dic[text] = default(int);
                    }

                }
                else
                {
                    dic[previosText] += int.Parse(text);
                }
                previosText = text;
                count++;
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}