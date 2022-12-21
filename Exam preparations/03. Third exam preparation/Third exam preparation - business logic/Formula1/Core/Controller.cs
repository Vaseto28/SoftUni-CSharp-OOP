namespace Formula1.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Formula1.Core.Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Models.Pilots;
    using Formula1.Repositories;
    using Formula1.Repositories.Contracts;
    using Formula1.Utilities;

    public class Controller : IController
    {
        private IRepository<IFormulaOneCar> cars;
        private IRepository<IPilot> pilots;
        private IRepository<IRace> races;

        public Controller()
        {
            this.cars = new FormulaOneCarRepository();
            this.pilots = new PilotRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilots.FindByName(pilotName);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidCastException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = this.cars.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            this.cars.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.races.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = this.pilots.FindByName(pilotFullName);
            if (pilot == null || !pilot.CanRace || race.Pilots.FirstOrDefault(x => x.FullName == pilotFullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (this.cars.FindByName(model) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car;
            if (type == typeof(Ferrari).Name)
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == typeof(Williams).Name)
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            this.cars.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (this.pilots.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            this.pilots.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (this.races.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            this.races.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in this.pilots.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.Append(pilot.ToString());
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var race in this.races.Models.Where(x => x.TookPlace))
            {
                sb.Append(race.RaceInfo());
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            IPilot winner = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList()[0];
            string firstPilotName = winner.FullName;
            winner.WinRace();

            string secondPilotName = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList()[1].FullName;
            string thirdPilotName = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList()[2].FullName;

            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {firstPilotName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {secondPilotName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {thirdPilotName} is third in the {raceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}

