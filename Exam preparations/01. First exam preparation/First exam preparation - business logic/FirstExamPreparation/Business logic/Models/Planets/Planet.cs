namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Utilities.Messages;

    public class Planet : IPlanet
    {
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;
        private string name;
        private double budget;
        private double militaryPower;

        public Planet(string name, double budget)
        {
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
            this.Name = name;
            this.Budget = budget;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => this.CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit) => this.units.AddItem(unit);

        public void AddWeapon(IWeapon weapon) => this.weapons.AddItem(weapon);

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");

            if (this.Army.Count == 0)
            {
                sb.AppendLine($"--Forces: No units");
            }
            else
            {
                List<string> names = new List<string>();

                foreach (var militaryUnit in this.Army)
                {
                    names.Add(militaryUnit.GetType().Name);
                }

                sb.AppendLine($"--Forces: {string.Join(", ", names)}");
            }

            if (this.Weapons.Count == 0)
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }
            else
            {
                List<string> names = new List<string>();

                foreach (var weapon in this.Weapons)
                {
                    names.Add(weapon.GetType().Name);
                }

                sb.AppendLine($"--Combat equipment: {String.Join(", ", names)}");
            }

            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount) => this.Budget += amount;

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var militaryUnit in this.Army)
            {
                militaryUnit.IncreaseEndurance();
            }
        }

        private double CalculateMilitaryPower()
        {
            double value = this.Army.Sum(x => x.EnduranceLevel) + this.Weapons.Sum(x => x.DestructionLevel);

            if (this.Army.FirstOrDefault(x => x.GetType().Name == typeof(AnonymousImpactUnit).Name) != null)
            {
                value += value * 0.3;
            }

            if (this.Weapons.FirstOrDefault(x => x.GetType().Name == typeof(NuclearWeapon).Name) != null)
            {
                value += value * 0.45;
            }

            return Math.Round(value, 3);
        }
    }
}

