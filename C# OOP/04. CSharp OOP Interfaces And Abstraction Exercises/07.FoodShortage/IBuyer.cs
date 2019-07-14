using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
    public interface IBuyer
    {
        void BuyFood();

        int Food { get; }

        string Name { get; }

        int Age { get; }
    }
}
