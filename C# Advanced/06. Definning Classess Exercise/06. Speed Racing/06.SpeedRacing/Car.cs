using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public bool Move(double amountOfKm)
        {
            var neededFule = amountOfKm * this.FuelConsumptionPerKilometer;

            if (neededFule > this.FuelAmount)
            {
                return false;
            }

            this.FuelAmount -= neededFule;
            this.TravelledDistance += amountOfKm;

            return true;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}
