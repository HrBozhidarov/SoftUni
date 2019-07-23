using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double AreaConditioner = 0.9d;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + AreaConditioner)
        {
        }

        public override void Refueled(double fuel)
        {
            this.FuelQuantity += fuel;
        }
    }
}
