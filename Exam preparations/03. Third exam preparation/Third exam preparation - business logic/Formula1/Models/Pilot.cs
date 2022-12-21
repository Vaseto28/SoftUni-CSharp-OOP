namespace Formula1.Models.Pilots
{
    using System;
    using Formula1.Models.Contracts;
    using Formula1.Utilities;

    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;

        public Pilot(string fullname)
        {
            this.FullName = fullname;
            this.CanRace = false;
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));
                }

                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => this.car;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }

                this.car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            this.car = car;
            this.CanRace = true;
        }

        public void WinRace() => this.NumberOfWins++;

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}

