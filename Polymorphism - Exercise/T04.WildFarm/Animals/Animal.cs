using System;
namespace T04.WildFarm.Animals
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public virtual string ProduceSound()
        {
            return base.ToString();
        }
    }
}

