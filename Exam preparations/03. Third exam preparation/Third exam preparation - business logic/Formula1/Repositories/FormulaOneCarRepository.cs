namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly HashSet<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            this.cars = new HashSet<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.cars;

        public void Add(IFormulaOneCar model) => this.cars.Add(model);

        public IFormulaOneCar FindByName(string name) => this.cars.FirstOrDefault(x => x.Model == name);

        public bool Remove(IFormulaOneCar model) => this.cars.Remove(model);
    }
}

