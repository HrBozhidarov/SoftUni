using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Entities.Contracts
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}
