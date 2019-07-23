using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private double extrafuelConsumption;
        private double normalfuelConsumption;

        public Bus(string typeOfVehicle, double FuelQuantity, double fuelConsumption, double tankCapacity) : base(typeOfVehicle, FuelQuantity, fuelConsumption, tankCapacity)
        {
            this.extrafuelConsumption = fuelConsumption + 1.4;
            this.normalfuelConsumption = fuelConsumption;
        }

        public void NeededFuelForJourney(string courseType)
        {
            if (courseType == "Drive")
            {
                this.FuelConsumption = extrafuelConsumption;
            }
            else if (courseType == "DriveEmpty")
            {
                this.FuelConsumption = normalfuelConsumption;
            }
        }
    }
}