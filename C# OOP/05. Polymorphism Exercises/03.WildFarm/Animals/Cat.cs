using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override Type[] FoodType => new Type[] { typeof(Vegetable), typeof(Meat) };
        public override double IncreaseWeightForEveryPiece => 0.30;

        public override void ProducingSound()
        {
            Console.WriteLine("Meow");
        }
    }
}