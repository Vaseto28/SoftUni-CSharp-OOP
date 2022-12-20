namespace Heroes.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly HashSet<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new HashSet<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        public void Add(IWeapon model) => this.weapons.Add(model);

        public IWeapon FindByName(string name) => this.weapons.FirstOrDefault(x => x.Name == name);

        public bool Remove(IWeapon model) => this.weapons.Remove(model);
    }
}

