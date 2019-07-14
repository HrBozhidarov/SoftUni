using System.Collections.Generic;

namespace _08.MilitaryElite
{
    public interface ICommando
    {
        ICollection<IMission> Missions { get; }
    }
}