using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(string typeOfVehicle, double FuelQuantity, double fuelConsumption, double tankCapacity) : base(typeOfVehicle, FuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = fuelConsumption + 1.6;
        }

        public override void Refuel(double newFuel)
        {
            if (this.IsFuelValid(newFuel))
            {
                double lostLiters = newFuel * 5 / 100.0;
                this.FuelQuantity += newFuel - lostLiters;
            }
        }
    }
}