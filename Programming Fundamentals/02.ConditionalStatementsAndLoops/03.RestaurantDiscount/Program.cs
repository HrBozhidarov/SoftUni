using System;

namespace P03__RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            var group = int.Parse(Console.ReadLine());
            var package = Console.ReadLine();

            var totalPrice = 0.0;
            var discount = 0.0;
            var hallName = string.Empty;

            if (group < 51)
            {
                totalPrice += 2500;
                hallName = "Small Hall";
            }
            else if (group < 101)
            {
                totalPrice += 5000;
                hallName = "Terrace";
            }
            else if (group < 121)
            {
                totalPrice += 7500;
                hallName = "Great Hall";
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            if (package == "Normal")
            {
                totalPrice += 500;
                discount = 0.05;
            }
            else if (package == "Gold")
            {
                totalPrice += 750;
                discount = 0.1;
            }
            else if (package == "Platinum")
            {
                totalPrice += 1000;
                discount = 0.15;
            }

            var pricePerPerson = (totalPrice - (totalPrice * discount)) / group;

            Console.WriteLine($"We can offer you the {hallName}");
            Console.WriteLine($"The price per person is {pricePerPerson:F2}$");
        }
    }
}
