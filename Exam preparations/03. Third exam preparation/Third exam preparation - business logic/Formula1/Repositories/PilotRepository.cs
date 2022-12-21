namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly HashSet<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new HashSet<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.pilots;

        public void Add(IPilot model) => this.pilots.Add(model);

        public IPilot FindByName(string name) => this.pilots.FirstOrDefault(x => x.FullName == name);

        public bool Remove(IPilot model) => this.pilots.Remove(model);
    }
}

