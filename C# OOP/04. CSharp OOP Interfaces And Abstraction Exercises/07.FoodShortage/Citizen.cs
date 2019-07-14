using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
    public class Citizen : IBuyer
    {
        private const int FoodIncrease = 10;

        public Citizen(string name, int age, string id, string birthDay)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDay = birthDay;
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

        public string Id
        {
            get;
            private set;
        }

        public string BirthDay
        {
            get;
            private set;
        }

        public int Food
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
