using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
    public interface IPerson : ILiveCitizen, ICitizen
    {
        int Age { get; }
    }
}
