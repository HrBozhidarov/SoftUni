using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.WildFarm
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public void TryToFeed(Food currentFood)
        {
            if (this.FoodType.Contains(currentFood.GetType()))
            {
                this.FoodEaten += currentFood.Quantity;
                this.Weight += currentFood.Quantity * IncreaseWeightForEveryPiece;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {currentFood.GetType().Name}!");
            }
        }

        public abstract Type[] FoodType { get; }
        public abstract double IncreaseWeightForEveryPiece { get; }
        public abstract void ProducingSound();

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}