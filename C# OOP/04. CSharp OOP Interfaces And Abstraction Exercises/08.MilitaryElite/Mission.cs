using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Mission : IMission
    {
        private const string MissionInProgress = "inProgress";
        private const string MissionCompleted = "Finished";

        private string state;
        public Mission(string name, string state)
        {
            this.Name = name;
            this.State = state;
        }

        public string Name
        {
            get;
            private set;
        }

        public string State
        {
            get => this.state;
            private set
            {
                if (!(value == MissionCompleted || value == MissionInProgress))
                {
                    throw new ArgumentException("Wrong mission state");
                }

                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.State = MissionCompleted;
        }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}"; 
        }
    }
}
