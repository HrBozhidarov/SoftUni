using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
    public class Pet : IPet
    {
        public Pet(string name, string birthDay)
        {
            this.Name = name;
            this.BirthDay = birthDay;
        }

        public string Name
        {
            get;
            private set;
        }

        public string BirthDay
        {
            get;
            private set;
        }
    }
}
