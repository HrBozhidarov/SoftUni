using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
    public class Person : IPerson
    {
        public Person(string name, int age, string id, string birthDay)
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
    }
}
