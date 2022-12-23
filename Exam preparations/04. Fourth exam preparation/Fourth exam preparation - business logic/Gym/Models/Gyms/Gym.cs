namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using global::Gym.Models.Athletes;
    using global::Gym.Models.Athletes.Contracts;
    using global::Gym.Models.Equipment.Contracts;

    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => this.Equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }

            this.athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment) => this.equipment.Add(equipment);

        public void Exercise()
        {
            foreach (var athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            string result = String.Empty;

            List<IAthlete> athletes = new List<IAthlete>();
            foreach (var athlete in this.Athletes)
            {
                athletes.Add(athlete);
            }

            result = $"{this.Name} is a {this.GetType().Name}{Environment.NewLine}Athletes: {String.Join(", ", athletes.Select(x => x.FullName))}{Environment.NewLine}Equipment total count: {this.Equipment.Count}{Environment.NewLine}Equipment total weight: {this.Equipment.Sum(x => x.Weight)} grams";

            if (this.Athletes.Count == 0)
            {
                result = $"{this.Name} is a {this.GetType().Name}{Environment.NewLine}Athletes: No athletes{Environment.NewLine}Equipment total count: {this.Equipment.Count}{Environment.NewLine}Equipment total weight: {this.Equipment.Sum(x => x.Weight)} grams";
            }

            return result;
        }

        public bool RemoveAthlete(IAthlete athlete) => this.athletes.Remove(athlete);
    }
}

