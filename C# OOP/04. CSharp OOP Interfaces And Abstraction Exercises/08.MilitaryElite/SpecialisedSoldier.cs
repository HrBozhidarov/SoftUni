using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private const string CorpAirforces = "Airforces";
        private const string CorpMarines = "Marines";
        private string corp;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
          : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => this.corp;
            private set
            {
                if (!(value == CorpMarines || value == CorpAirforces))
                {
                    throw new ArgumentException("Wrong corp name");
                }

                this.corp = value;
            }
        }

        public override string ToString()
        {
            return base.ToString().TrimEnd() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
