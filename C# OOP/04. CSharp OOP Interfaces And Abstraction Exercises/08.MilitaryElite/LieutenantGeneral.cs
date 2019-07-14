using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
           : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<ISoldier>();
        }

        public ICollection<ISoldier> Privates
        {
            get;
            private set;
        }

        public void AddPrivate(ISoldier @private)
        {
            this.Privates.Add(@private);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString().TrimEnd());
            result.AppendLine("Privates:");

            foreach (var currentPrivate in this.Privates)
            {
                result.AppendLine("  " + currentPrivate.ToString().TrimEnd());
            }

            return result.ToString().TrimEnd();
        }
    }
}
