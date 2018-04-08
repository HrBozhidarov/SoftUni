using System;

namespace P01_ChooseADrink
{
    class Program
    {
        static void Main(string[] args)
        {
            var profession = Console.ReadLine();

            if (profession== "Athlete")
            {
                Console.WriteLine("Water");
            }
            else if (profession == "Businessman" || profession == "Businesswoman")
            {
                Console.WriteLine("Coffee");
            }
            else if (profession == "SoftUni Student")
            {
                Console.WriteLine("Beer");
            }
            else
            {
                Console.WriteLine("Tea");
            }
        }
    }
}
