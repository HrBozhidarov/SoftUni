using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber
        {
            get;
            private set;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString().TrimEnd());
            result.AppendLine($"Code Number: {this.CodeNumber}");

            return result.ToString();
        }
    }
}
