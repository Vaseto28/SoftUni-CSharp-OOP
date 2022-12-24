namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using Contracts;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double multiplierOfTheFirstRacer = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                multiplierOfTheFirstRacer = 1.2;
            }
            else
            {
                multiplierOfTheFirstRacer = 1.1;
            }

            double multiplierOfTheSecondRacer = 0;
            if (racerTwo.RacingBehavior == "Strict")
            {
                multiplierOfTheSecondRacer = 1.2;
            }
            else
            {
                multiplierOfTheSecondRacer = 1.1;
            }

            decimal chanceOfWinningOfTheFirstRacer = (decimal)(racerOne.Car.HorsePower * racerOne.DrivingExperience * multiplierOfTheFirstRacer);
            decimal chanceOfWinningOfTheSecondRacer = (decimal)(racerTwo.Car.HorsePower * racerTwo.DrivingExperience * multiplierOfTheSecondRacer);

            if (chanceOfWinningOfTheSecondRacer < chanceOfWinningOfTheFirstRacer)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username, racerTwo.Username);
            }
        }
    }
}

