using System;
namespace Restaurant
{
    public class Cake : Dessert
    {
        public const double Grams = 250d;
        public const double Calories = 1000d;
        public const decimal CakePrice = 5m;

        public Cake(string name) : base(name, CakePrice, Grams, Calories)
        {

        }
    }
}

