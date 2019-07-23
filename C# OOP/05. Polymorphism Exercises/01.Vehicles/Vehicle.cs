using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public abstract void Refueled(double fuel);

        public string Drive(double distance)
        {
            var currentQuantity = distance * this.FuelConsumption;
            if (this.FuelQuantity - currentQuantity >= 0)
            {
                this.FuelQuantity -= currentQuantity;

                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity.ToString("F2")}";
        }
    }
}
