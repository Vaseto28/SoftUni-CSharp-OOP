using System;
namespace Animals
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name}{Environment.NewLine}{this.Name} {this.Age} {this.Gender}{Environment.NewLine}{this.ProduceSound()}";
        }
    }
}

