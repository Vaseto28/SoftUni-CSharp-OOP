namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly HashSet<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new HashSet<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        public void AddItem(IWeapon model) => this.weapons.Add(model);

        public IWeapon FindByName(string name) => this.weapons.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name) => this.weapons.Remove(this.weapons.FirstOrDefault(x => x.GetType().Name == name));
    }
}

