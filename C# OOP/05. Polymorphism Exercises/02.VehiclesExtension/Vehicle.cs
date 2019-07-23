using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(string typeOfVehicle, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TypeOfVehicle = typeOfVehicle;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }

        public string TypeOfVehicle { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; set; }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity || value < 0)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel <= this.FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double newFuel)
        {
            if (IsFuelValid(newFuel))
            {
                this.FuelQuantity += newFuel;
            } 
        }

        protected bool IsFuelValid(double newFuel)
        {
            bool isFuelValid = true;

            if (newFuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                isFuelValid = false;
            }
            else if (this.TankCapacity < this.FuelQuantity + newFuel)
            {
                Console.WriteLine($"Cannot fit {newFuel} fuel in the tank");
                isFuelValid = false;
            }
            return isFuelValid;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}