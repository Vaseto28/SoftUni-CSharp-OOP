namespace Heroes.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly HashSet<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new HashSet<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroes;

        public void Add(IHero model) => this.heroes.Add(model);

        public IHero FindByName(string name) => this.heroes.FirstOrDefault(x => x.Name == name);

        public bool Remove(IHero model) => this.heroes.Remove(model);
    }
}

