using System;
namespace Restaurant
{
    public class Beverage : Product
    {
        public double Mililiters { get; set; }

        public Beverage(string name, decimal price, double mililiters) : base(name, price)
        {
            this.Name = name;
            this.Price = price;
            this.Mililiters = mililiters;
        }
    }
}

