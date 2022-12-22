namespace Gym.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using Gym.Repositories.Contracts;

    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this.gyms.First(x => x.Name == gymName);

            if (athleteType == "Boxer")
            {
                IAthlete athlete = new Boxer(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name == "BoxingGym")
                {
                    gym.AddAthlete(athlete);
                }
                else
                {
                    throw new InvalidOperationException("The gym is not appropriate.");
                }
            }
            else if (athleteType == "Weightlifter")
            {
                IAthlete athlete = new Weightlifter(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name == "WeightliftingGym")
                {
                    gym.AddAthlete(athlete);
                }
                else
                {
                    throw new InvalidOperationException("The gym is not appropriate.");
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                IEquipment equipment = new BoxingGloves();
                this.equipment.Add(equipment);
                return $"Successfully added {equipmentType}.";
            }
            else if (equipmentType == "Kettlebell")
            {
                IEquipment equipment = new Kettlebell();
                this.equipment.Add(equipment);
                return $"Successfully added {equipmentType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                IGym gym = new BoxingGym(gymName);
                this.gyms.Add(gym);
                return $"Successfully added {gymType}.";
            }
            else if (gymType == "WeightliftingGym")
            {
                IGym gym = new WeightliftingGym(gymName);
                this.gyms.Add(gym);
                return $"Successfully added {gymType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.First(x => x.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            this.equipment.Remove(equipment);

            IGym gym = this.gyms.First(x => x.Name == gymName);

            gym.Equipment.Add(equipment);
            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in this.gyms)
            {
                sb.Append(gym.GymInfo());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.First(x => x.Name == gymName);
            gym.Exercise();

            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}

