using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
    public interface IRobbot : ICitizen
    {
        string Model { get; }
    }
}
