namespace Heroes.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Heroes.Repositories;
    using Heroes.Repositories.Contracts;

    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.FindByName(heroName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            IWeapon weapon = this.weapons.FindByName(weaponName);
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            IHero hero;
            if (type == typeof(Barbarian).Name)
            {
                hero = new Barbarian(name, health, armour);
                this.heroes.Add(hero);
                return $"Successfully added Barbarian {name} to the collection.";
            }
            else if (type == typeof(Knight).Name)
            {
                hero = new Knight(name, health, armour);
                this.heroes.Add(hero);
                return $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon weapon;
            if (type == typeof(Mace).Name)
            {
                weapon = new Mace(name, durability);
            }
            else if (type == typeof(Claymore).Name)
            {
                weapon = new Claymore(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            this.weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");

                if (hero.Weapon == null)
                {
                    sb.AppendLine("--Weapon: Unarmed");
                }
                else
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            return map.Fight(this.heroes.Models.ToList());
        }
    }
}

