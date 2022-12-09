using System;
namespace Restaurant
{
    public class Fish : MainDish
    {
        public const double Grams = 22d;

        public Fish(string name, decimal price) : base(name, price, Grams)
        {

        }
    }
}

