using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            set => this.name = value;
            get => this.name;
        }

        public int Age
        {
            set => this.age = value;
            get => this.age;
        }
    }
}
