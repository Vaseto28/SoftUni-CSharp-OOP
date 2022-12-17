namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IMilitaryUnit militaryUnit;
            if (unitTypeName == typeof(SpaceForces).Name)
            {
                militaryUnit = new SpaceForces();

                if (planet.Army.FirstOrDefault(x => x.GetType().Name == typeof(SpaceForces).Name) != null)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }
            }
            else if (unitTypeName == typeof(AnonymousImpactUnit).Name)
            {
                militaryUnit = new AnonymousImpactUnit();

                if (planet.Army.FirstOrDefault(x => x.GetType().Name == typeof(AnonymousImpactUnit).Name) != null)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }
            }
            else if (unitTypeName == typeof(StormTroopers).Name)
            {
                militaryUnit = new StormTroopers();

                if (planet.Army.FirstOrDefault(x => x.GetType().Name == typeof(StormTroopers).Name) != null)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IWeapon weapon;
            if (weaponTypeName == typeof(BioChemicalWeapon).Name)
            {
                weapon = new BioChemicalWeapon(destructionLevel);

                if (planet.Weapons.FirstOrDefault(x => x.GetType().Name == typeof(BioChemicalWeapon).Name) != null)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }
            }
            else if (weaponTypeName == typeof(NuclearWeapon).Name)
            {
                weapon = new NuclearWeapon(destructionLevel);

                if (planet.Weapons.FirstOrDefault(x => x.GetType().Name == typeof(NuclearWeapon).Name) != null)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }
            }
            else if (weaponTypeName == typeof(SpaceMissiles).Name)
            {
                weapon = new SpaceMissiles(destructionLevel);

                if (planet.Weapons.FirstOrDefault(x => x.GetType().Name == typeof(SpaceMissiles).Name) != null)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != null)
            {
                throw new InvalidOperationException(String.Format(OutputMessages.ExistingPlanet, name));
            }

            IPlanet planet = new Planet(name, budget);
            this.planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }
        
        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.Append(planet.PlanetInfo());
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attacker = this.planets.FindByName(planetOne);
            IPlanet defender = this.planets.FindByName(planetTwo);

            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                return PlanetWinTheWar(attacker, defender);
            }
            else if (defender.MilitaryPower > attacker.MilitaryPower)
            {
                return PlanetWinTheWar(defender, attacker);
            }
            else
            {
                IWeapon attackerNuclearWeapon = attacker.Weapons.FirstOrDefault(x => x.GetType().Name == typeof(NuclearWeapon).Name);
                IWeapon defenderNuclearWeapon = defender.Weapons.FirstOrDefault(x => x.GetType().Name == typeof(NuclearWeapon).Name);

                if ((attackerNuclearWeapon == null && defenderNuclearWeapon == null) ||
                    (attackerNuclearWeapon != null && defenderNuclearWeapon != null))
                {
                    attacker.Spend(attacker.Budget * 0.5);
                    defender.Spend(defender.Budget * 0.5);

                    return OutputMessages.NoWinner;
                }
                else
                {
                    if (attackerNuclearWeapon == null && defenderNuclearWeapon != null)
                    {
                        return PlanetWinTheWar(defender, attacker);
                    }
                    else
                    {
                        return PlanetWinTheWar(attacker, defender);
                    }
                }
            }
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        private string PlanetWinTheWar(IPlanet winner, IPlanet loser)
        {
            winner.Spend(winner.Budget * 0.5);
            winner.Profit(loser.Budget * 0.5);

            foreach (var militaryUnit in loser.Army)
            {
                winner.Profit(militaryUnit.Cost);
            }

            foreach (var weapon in loser.Weapons)
            {
                winner.Profit(weapon.Price);
            }

            this.planets.RemoveItem(loser.Name);
            return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }
    }
}

