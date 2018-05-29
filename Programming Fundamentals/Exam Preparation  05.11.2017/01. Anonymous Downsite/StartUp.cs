using System;
using System.Collections.Generic;
using System.Numerics;


namespace ExamSoftUni
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var securityKey = int.Parse(Console.ReadLine());
            var totalLosses = 0M;
            var sites = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var site = line[0];
                sites.Add(site);
                var siteVisites = decimal.Parse(line[1]);
                var siteCommercialPricePerVisit = decimal.Parse(line[2]);
                totalLosses += (siteVisites * siteCommercialPricePerVisit);
            }

            Console.WriteLine(string.Join(Environment.NewLine, sites));
            Console.WriteLine($"Total Loss: {totalLosses:F20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey, sites.Count)}");
        }
    }
}