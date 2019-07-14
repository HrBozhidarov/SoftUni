using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public interface IEngineer
    {
        ICollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
