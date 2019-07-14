using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public interface IRobbot : ICitizen
    {
        string Model { get; }
    }
}
