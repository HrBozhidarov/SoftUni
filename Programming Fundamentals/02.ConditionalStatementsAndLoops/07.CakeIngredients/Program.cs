using System;

namespace P07_CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 20; i++)
            {
                var ingr = Console.ReadLine();
                if (ingr != "Bake!")
                {
                    Console.WriteLine($"Adding ingredient {ingr}.");
                }
                else
                {
                    Console.WriteLine($"Preparing cake with {i} ingredients.");
                    break;
                }
            }
        }
    }
}
