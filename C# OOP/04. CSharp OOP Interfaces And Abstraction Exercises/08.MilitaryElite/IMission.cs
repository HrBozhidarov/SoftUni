using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public interface IMission
    {
        string Name { get; }

        string State { get; }

        void CompleteMission();
    }
}
