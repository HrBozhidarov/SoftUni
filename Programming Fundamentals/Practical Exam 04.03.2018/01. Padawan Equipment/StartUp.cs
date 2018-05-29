using System;

namespace Exam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var amountOfMoney = decimal.Parse(Console.ReadLine());
            var countOfStudents = int.Parse(Console.ReadLine());
            var priceOfLightSabre = decimal.Parse(Console.ReadLine());
            var priceOfRob = decimal.Parse(Console.ReadLine());
            var PriceOfBelt = decimal.Parse(Console.ReadLine());

            var freeBelts = countOfStudents / 6;
            var sabrePrice = priceOfLightSabre * (Math.Ceiling(1.1M * countOfStudents));
            var robePrice = countOfStudents * priceOfRob;
            var beltPrice = PriceOfBelt * (countOfStudents - freeBelts);

            var result = sabrePrice + robePrice + beltPrice;

            if (result <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {result:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {result - amountOfMoney:F2}lv more.");
            }
        }
    }
}