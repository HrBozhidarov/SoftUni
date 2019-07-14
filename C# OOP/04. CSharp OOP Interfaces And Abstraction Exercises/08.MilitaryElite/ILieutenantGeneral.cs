using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public interface ILieutenantGeneral
    {
        ICollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);
    }
}
