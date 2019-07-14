using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var citizens = new List<IBuyer>();
            var input = string.Empty;

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split();
                IBuyer buyer = null;

                if (data.Length == 4)
                {
                    buyer = new Citizen(data[0], int.Parse(data[1]), data[2], data[3]);
                }
                else
                {
                    buyer = new Rebel(data[0], int.Parse(data[1]), data[2]);
                }

                citizens.Add(buyer);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                var citizen = citizens.FirstOrDefault(x => x.Name == input);

                if (citizen != null)
                {
                    citizen.BuyFood();
                }
            }

            Console.WriteLine(citizens.Sum(x => x.Food));
        }
    }
}
