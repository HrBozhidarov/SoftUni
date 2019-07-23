using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(string typeOfVehicle, double FuelQuantity, double fuelConsumption, double tankCapacity) : base(typeOfVehicle, FuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = fuelConsumption + 0.9;
        }
    }
}