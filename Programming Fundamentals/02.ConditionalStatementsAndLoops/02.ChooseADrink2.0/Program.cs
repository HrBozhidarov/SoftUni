using System;

namespace P02_ChooseADrink2
{
    class Program
    {
        static void Main(string[] args)
        {
            var profession = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());
            const double waterPrice = 0.7;
            const double coffeePrice = 1.0;
            const double beerPrice = 1.7;
            const double teaPrice = 1.2;

            if (profession == "Athlete")
            {
                Console.WriteLine($"The {profession} has to pay {quantity*waterPrice:F2}.");
            }
            else if (profession == "Businessman" || profession == "Businesswoman")
            {
                Console.WriteLine($"The {profession} has to pay {quantity * coffeePrice:F2}.");
            }
            else if (profession == "SoftUni Student")
            {
                Console.WriteLine($"The {profession} has to pay {quantity * beerPrice:F2}.");
            }
            else
            {
                Console.WriteLine($"The {profession} has to pay {quantity * teaPrice:F2}.");
            }
        }
    }
}
