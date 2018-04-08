using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dic = new Dictionary<char, char>();
            var incrementCharec = 'n';
            var result = string.Empty;

            for (char ch = 'a'; ch < 'n'; ch++)
            {
                dic.Add(ch, incrementCharec++);
            }

            incrementCharec = 'm';

            for (char ch = 'z'; ch >= 'n'; ch--)
            {
                dic.Add(ch, incrementCharec--);
            }

            var pattern = "(<p>.*?</p>)";
            var regex = new Regex(pattern);

            var allPTags = new List<string>();

            MatchCollection matchCollection = regex.Matches(input);

            foreach (Match item in matchCollection)
            {
                var textInPTag = item.Value.Substring(3, item.Value.Length - 7);
                regex = new Regex("[^a-z0-9]+");
                textInPTag = regex.Replace(textInPTag, " ");

                for (int i = 0; i < textInPTag.Length; i++)
                {
                    if (dic.ContainsKey(textInPTag[i]))
                    {
                        result += dic[textInPTag[i]];
                    }
                    else if (textInPTag[i] >= '0' && textInPTag[i] <= '9')
                    {
                        result += textInPTag[i];
                    }
                    else
                    {
                        result += " ";
                    }
                }
            }

            Console.WriteLine(result);
        }
    }