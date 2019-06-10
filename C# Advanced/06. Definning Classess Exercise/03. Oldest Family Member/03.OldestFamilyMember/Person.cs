using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age)
            : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
            : this(age)
        {
            this.Name = name;
        }

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

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
