namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly HashSet<IRace> races;

        public RaceRepository()
        {
            this.races = new HashSet<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.races;

        public void Add(IRace model) => this.races.Add(model);

        public IRace FindByName(string name) => this.races.FirstOrDefault(x => x.RaceName == name);

        public bool Remove(IRace model) => this.races.Remove(model);
    }
}

