using System;
using System.Collections.Generic;
using System.Text;

namespace Turshia.App.Models
{
    [Flags]
    public enum SectorType
    {
        Customers = 1,
        Marketing = 2,
        Finances = 4,
        Internal = 8,
        Management = 16
    }
}