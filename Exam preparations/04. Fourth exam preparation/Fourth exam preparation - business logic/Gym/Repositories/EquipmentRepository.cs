namespace Gym.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipment;

        public EquipmentRepository()
        {
            this.equipment = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => this.equipment;

        public void Add(IEquipment model) => this.equipment.Add(model);

        public IEquipment FindByType(string type) => this.equipment.FirstOrDefault(x => x.GetType().Name == type);

        public bool Remove(IEquipment model) => this.equipment.Remove(model);
    }
}

