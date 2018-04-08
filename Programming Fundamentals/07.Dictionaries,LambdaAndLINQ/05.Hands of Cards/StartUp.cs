namespace P05_HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var text = string.Empty;
            var dic = new Dictionary<string, string>();
            var previosText = string.Empty;
            var compear = new Dictionary<string, int>();


            compear["2"] = 2;
            compear["3"] = 3;
            compear["4"] = 4;
            compear["5"] = 5;
            compear["6"] = 6;
            compear["7"] = 7;
            compear["8"] = 8;
            compear["9"] = 9;
            compear["10"] = 10;
            compear["J"] = 11;
            compear["Q"] = 12;
            compear["K"] = 13;
            compear["A"] = 14;
            compear["S"] = 4;
            compear["H"] = 3;
            compear["D"] = 2;
            compear["C"] = 1;

            while ((text = Console.ReadLine()) != "JOKER")
            {
                var data = text.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                var name = data[0];
                var sourceCard = data[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!dic.ContainsKey(name))
                {
                    dic[name] = "";
                }

                for (int i = 0; i < sourceCard.Length; i++)
                {
                    var currentHand = sourceCard[i];

                    if (!dic[name].Contains(currentHand))
                    {
                        dic[name] += currentHand + ',';
                    }
                }
            }

            foreach (var item in dic)
            {
                var currentItem = item.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var sum = 0;

                for (int i = 0; i < currentItem.Length; i++)
                {
                    if (currentItem[i][0].ToString() == "1" && currentItem[i][1].ToString() == "0")
                    {
                        sum += (compear[currentItem[i][0].ToString() + currentItem[i][1].ToString()] * compear[currentItem[i][2].ToString()]);
                    }
                    else
                    {
                        sum += (compear[currentItem[i][0].ToString()] * compear[currentItem[i][1].ToString()]);
                    }

                }

                Console.WriteLine($"{item.Key}: {sum}");
            }
        }
    }
}