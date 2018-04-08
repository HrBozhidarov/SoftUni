namespace P04_FixEmails
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var text = string.Empty;
            var dic = new Dictionary<string, string>();
            int count = 1;
            var previosText = string.Empty;

            while ((text = Console.ReadLine()) != "stop")
            {
                if (count % 2 == 1)
                {
                    if (!dic.ContainsKey(text))
                    {
                        dic[text] = default(string);
                    }

                }
                else
                {
                    if (text.ToLower().EndsWith("us") || text.ToLower().EndsWith("us"))
                    {
                        dic.Remove(previosText);
                    }
                    else
                    {
                        dic[previosText] = text;
                    }
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