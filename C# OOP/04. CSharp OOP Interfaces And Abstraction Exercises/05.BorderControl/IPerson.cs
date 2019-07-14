using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public interface IPerson : ICitizen
    {
        string Name { get; }

        int Age { get; }
    }
}
