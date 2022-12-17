namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using Contracts;
    using PlanetWars.Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private int enduranceLevel = 1;

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel
        {
            get => this.enduranceLevel;
            private set
            {
                this.enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
            if (this.EnduranceLevel > 20)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}

