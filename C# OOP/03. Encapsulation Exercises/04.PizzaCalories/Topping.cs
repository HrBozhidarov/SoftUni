using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const string ToppingMeatType = "meat";
        private const string ToppingVeggiesType = "veggies";
        private const string ToppingCheeseType = "cheese";
        private const string ToppingSauceType = "sauce";
        private const string InvalidToppingTypeMessage = "Cannot place {0} on top of your pizza.";
        private const string InvalidToppingWeightMessage = "{0} weight should be in the range [1..50].";

        private readonly Dictionary<string, double> modifiers;

        private string name;
        private double weight;

        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.modifiers = new Dictionary<string, double>()
            {
                [ToppingMeatType] = 1.2,
                [ToppingVeggiesType] = 0.8,
                [ToppingCheeseType] = 1.1,
                [ToppingSauceType] = 0.9
            };
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                var currentValue = value.ToLower();

                if (!(ToppingCheeseType == currentValue || ToppingMeatType == currentValue ||
                    ToppingSauceType == currentValue || ToppingVeggiesType == currentValue))
                {
                    throw new ArgumentException(string.Format(InvalidToppingTypeMessage, value));
                }

                this.name = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(InvalidToppingWeightMessage, this.name));
                }

                this.weight = value;
            }
        }

        public double Calories => this.weight * this.modifiers[this.name.ToLower()] * 2;
    }
}
