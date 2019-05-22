using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dic = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var strNum = Console.ReadLine();

                if (!dic.ContainsKey(strNum))
                {
                    dic[strNum] = 0;
                }

                dic[strNum]++;
            }

            var result = dic.Where(x => x.Value % 2 == 0).Select(x => x.Key).ToArray()[0];

            Console.WriteLine(result);
        }
    }
}
