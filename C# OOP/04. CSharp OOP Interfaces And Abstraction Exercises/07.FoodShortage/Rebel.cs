using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
    public class Rebel : IBuyer
    {
        private const int FoodIncrease = 5;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public int Food
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Age
        {
            get;
            private set;
        }

        public string Group
        {
            get;
            private set;
        }

        public void BuyFood()
        {
            this.Food += FoodIncrease;
        }
    }
}
