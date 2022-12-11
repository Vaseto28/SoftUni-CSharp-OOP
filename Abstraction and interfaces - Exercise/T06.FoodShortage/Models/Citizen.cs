﻿namespace T06.FoodStorage
{
    public class Citizen : IHuman, IBuyer
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthday { get; private set; }

        public int Food { get; private set; }

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
            this.Food = 0;
        }

        public int BuyFood()
        {
            this.Food += 10;
            return 10;
        }
    }
}

