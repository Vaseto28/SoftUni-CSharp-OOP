namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly HashSet<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new HashSet<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets;

        public void AddItem(IPlanet model) => this.planets.Add(model);

        public IPlanet FindByName(string name) => this.planets.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name) => this.planets.Remove(this.planets.FirstOrDefault(x => x.Name == name));
    }
}

