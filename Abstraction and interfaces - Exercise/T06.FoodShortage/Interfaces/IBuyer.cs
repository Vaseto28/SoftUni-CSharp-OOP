using System;
namespace T06.FoodStorage
{
    public interface IBuyer
    {
        public int Food { get; }

        int BuyFood();
    }
}

