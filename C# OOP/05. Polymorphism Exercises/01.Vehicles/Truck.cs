using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double AreaConditioner = 1.6d;
        private const double GetFuel = 0.95d;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + AreaConditioner)
        {
        }

        public override void Refueled(double fuel)
        {
            this.FuelQuantity += fuel * GetFuel;
        }
    }
}
