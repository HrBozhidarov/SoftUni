using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        public Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id
        {
            get;
            protected set;
        }

        public string FirstName
        {
            get;
            protected set;
        }

        public string LastName
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
        }
    }
}
