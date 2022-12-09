using System;
namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsepower, double fuel) : base(horsepower, fuel)
        {
            this.HorsePower = horsepower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = 3;
        }
    }
}

