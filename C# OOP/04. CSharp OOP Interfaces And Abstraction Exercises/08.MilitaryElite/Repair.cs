using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Repair : IRepair
    {
        public Repair(string name, int hourseWork)
        {
            this.Name = name;
            this.HourseWork = hourseWork;
        }
        public string Name
        {
            get;
            private set;
        }

        public int HourseWork
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.HourseWork}";
        }
    }
}
