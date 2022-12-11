using System;
namespace T06.FoodStorage
{
    public interface IHuman : IBuyer
    {
        public string Name { get; }

        public int Age { get; }
    }
}

