namespace Animals
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}{Environment.NewLine}DJAAF";
        }
    }
}

