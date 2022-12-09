using System;
namespace NeedForSpeed
{
    public class FamilyCar : Car
    {
        public FamilyCar(int horsepower, double fuel) : base(horsepower, fuel)
        {
            this.HorsePower = horsepower;
            this.Fuel = fuel;
        }
    }
}

