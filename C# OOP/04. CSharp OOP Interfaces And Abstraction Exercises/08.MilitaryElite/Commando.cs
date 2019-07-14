using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions
        {
            get;
            private set;
        }

        public void AddMission(IMission mission)
        {
            this.Missions.Add(mission);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString().TrimEnd());
            result.AppendLine($"Missions:");

            foreach (var mission in this.Missions)
            {
                result.AppendLine("  " + mission.ToString().TrimEnd());
            }

            return result.ToString().TrimEnd();
        }
    }
}
