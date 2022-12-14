using System;
namespace T02.VehiclesExtention
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public bool Drive(double distance)
        {
            double neededLitres = this.FuelConsumption * distance;

            if (this.FuelQuantity >= neededLitres)
            {
                this.FuelQuantity -= neededLitres;
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract bool Refuel(double litres);
    }
}

