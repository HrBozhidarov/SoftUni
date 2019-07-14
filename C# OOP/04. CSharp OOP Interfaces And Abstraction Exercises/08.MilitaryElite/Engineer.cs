using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs
        {
            get;
            private set;
        }

        public void AddRepair(IRepair repair)
        {
            this.Repairs.Add(repair);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString().TrimEnd());
            result.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                result.AppendLine("  " + repair.ToString().TrimEnd());
            }

            return result.ToString().TrimEnd();
        }
    }
}
