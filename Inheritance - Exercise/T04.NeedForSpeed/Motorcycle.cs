using System;
namespace NeedForSpeed
{
    public class Motorcycle : Vehicle
    {


        public Motorcycle(int horsepower, double fuel) : base(horsepower, fuel)
        {
            this.HorsePower = horsepower;
            this.Fuel = fuel;
        }
    }
}

