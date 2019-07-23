using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm 
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override Type[] FoodType => new Type[] { typeof(Meat) };
        public override double IncreaseWeightForEveryPiece => 0.25;

        public override void ProducingSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}