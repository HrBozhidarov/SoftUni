using System;

namespace P15_NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var peshoDemage = int.Parse(Console.ReadLine());
            var goshoDemage = int.Parse(Console.ReadLine());
            var peshoHealth = 100;
            var goshoHealth = 100;
            var round = 1;

            while (true)
            {
                if (round % 2 == 0)
                {
                    peshoHealth -= goshoDemage;

                    if (peshoHealth <= 0) break;

                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHealth} health.");
                }
                else
                {
                    goshoHealth -= peshoDemage;

                    if (goshoHealth <= 0) break;

                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHealth} health.");
                }

                if (round % 3 == 0)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }

                round++;
            }

            var winer = Math.Max(peshoHealth, goshoHealth);
            var winerText = winer == peshoHealth ? $"Pesho won in {round}th round." : $"Gosho won in {round}th round.";

            Console.WriteLine(winerText);
        }
    }
}
