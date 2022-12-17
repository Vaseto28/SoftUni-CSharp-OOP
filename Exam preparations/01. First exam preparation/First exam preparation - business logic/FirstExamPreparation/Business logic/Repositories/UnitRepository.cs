namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly HashSet<IMilitaryUnit> militaryUnits;

        public UnitRepository()
        {
            this.militaryUnits = new HashSet<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.militaryUnits;

        public void AddItem(IMilitaryUnit model) => this.militaryUnits.Add(model);

        public IMilitaryUnit FindByName(string name) => this.militaryUnits.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name) => this.militaryUnits.Remove(this.militaryUnits.FirstOrDefault(x => x.GetType().Name == name));
    }
}

