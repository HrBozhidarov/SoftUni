using System;
using System.Linq;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaData = Console.ReadLine().Split();
                var doughData = Console.ReadLine().Split();

                var pizza = new Pizza(pizzaData[1]);
                var dough = new Dough(doughData[1], doughData[2], double.Parse(doughData[3]));

                pizza.AddDough(dough);

                var line = string.Empty;

                while ((line = Console.ReadLine()) != "END")
                {
                    var toppingData = line.Split().Skip(1).ToArray();

                    var topping = new Topping(toppingData[0], double.Parse(toppingData[1]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
