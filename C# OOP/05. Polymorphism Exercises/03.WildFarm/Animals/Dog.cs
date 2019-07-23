using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override Type[] FoodType => new Type[] { typeof(Meat) };
        public override double IncreaseWeightForEveryPiece => 0.40;

        public override void ProducingSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}