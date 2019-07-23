using System;
using System.Collections.Generic;
using System.Text;
using _03.WildFarm.Foods;

namespace _03.WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override Type[] FoodType => new Type[] { typeof(Vegetable), typeof(Meat), typeof(Fruit), typeof(Seeds) };
        public override double IncreaseWeightForEveryPiece => 0.35;

        public override void ProducingSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}