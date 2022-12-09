using System;
namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public const double CoffeeMililiters = 50d;

        public const decimal CoffeePrice = 3.50m;

        public double Caffeine { get; set; }

        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMililiters)
        {
            this.Caffeine = caffeine;
        }
    }
}

