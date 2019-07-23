using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override Type[] FoodType => new Type[] { typeof(Vegetable), typeof(Fruit) };
        public override double IncreaseWeightForEveryPiece => 0.10;

        public override void ProducingSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
