using System;

namespace P08_CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var calories = 0;

            for (int i = 1; i <= n; i++)
            {
                string ingredients = Console.ReadLine().ToLower();

                if (ingredients == "cheese") calories += 500; 

                if (ingredients == "tomato sauce") calories += 150;

                if (ingredients == "salami") calories += 600;

                if (ingredients == "pepper") calories += 50;
            }
            Console.WriteLine($"Total calories: {calories}");
        }
    }
}
