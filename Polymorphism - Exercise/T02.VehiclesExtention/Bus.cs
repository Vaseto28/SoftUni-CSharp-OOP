using System;
namespace T02.VehiclesExtention
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool DriveNotEmpty(double distance)
        {
            this.FuelConsumption += 1.4;
            double neededLitres = this.FuelConsumption * distance;
            this.FuelConsumption -= 1.4;

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

        public override bool Refuel(double litres)
        {
            this.FuelQuantity += litres;

            if (this.FuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity -= litres;
                return false;
            }

            return true;
        }
    }
}

