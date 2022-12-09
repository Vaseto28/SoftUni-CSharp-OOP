using System;
namespace NeedForSpeed
{
    public class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horsepower, double fuel) : base(horsepower, fuel)
        {
            this.HorsePower = horsepower;
            this.Fuel = fuel;
        }
    }
}

