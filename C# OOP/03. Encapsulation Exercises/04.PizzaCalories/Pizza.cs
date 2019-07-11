using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int maxToppings = 10;
        private const string InvalidPizzaNameMessage = "Pizza name should be between 1 and 15 symbols.";
        private const string InvalidToppingRangeMessage = "Number of toppings should be in range [0..10].";

        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == null || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException(InvalidPizzaNameMessage);
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == maxToppings)
            {
                throw new IndexOutOfRangeException(InvalidToppingRangeMessage);
            }

            this.toppings.Add(topping);
        }

        public void AddDough(Dough dough)
        {
            this.dough = dough;
        }

        public override string ToString()
        {
            var doughCalories = this.dough.ExactCalories;
            var toppingsCalories = this.toppings.Sum(x => x.Calories);
            var totalCalories = doughCalories + toppingsCalories;

            return $"{this.Name} - {totalCalories.ToString("F2")} Calories.";
        }
    }
}
