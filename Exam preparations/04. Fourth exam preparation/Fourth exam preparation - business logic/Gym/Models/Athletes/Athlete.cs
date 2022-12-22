namespace Gym.Models.Athletes
{
    using System;
    using Contracts;

    public abstract class Athlete : IAthlete
    {
        private string fullname;
        private string motivation;
        private int numberOfMedals;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        public string FullName
        {
            get => this.fullname;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                }

                this.fullname = value;
            }
        }

        public string Motivation
        {
            get => this.motivation;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The motivation cannot be null or empty.");
                }

                this.motivation = value;
            }
        }

        public int Stamina { get; protected set; }

        public int NumberOfMedals
        {
            get => this.numberOfMedals;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                }

                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}

