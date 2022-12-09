﻿using System;
namespace Animals
{
    public class Kitten : Cat
    {
        public const string Gender = "Female";

        public Kitten(string name, int age) : base(name, age, Gender)
        {

        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}

