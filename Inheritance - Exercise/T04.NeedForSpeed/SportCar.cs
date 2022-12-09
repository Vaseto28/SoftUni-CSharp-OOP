using System;
namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsepower, double fuel) : base(horsepower, fuel)
        {
            this.HorsePower = horsepower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = 10;
        }
    }
}

