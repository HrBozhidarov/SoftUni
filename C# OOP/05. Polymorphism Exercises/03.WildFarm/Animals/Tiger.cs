using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override Type[] FoodType => new Type[] { typeof(Meat) };
        public override double IncreaseWeightForEveryPiece => 1;

        public override void ProducingSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}