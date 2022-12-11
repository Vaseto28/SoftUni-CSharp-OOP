﻿using System;
using PersonInfo;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Birthdate { get; set; }

        public string Id { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
    }
}

