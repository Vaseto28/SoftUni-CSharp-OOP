namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Formula1.Models.Contracts;
    using Formula1.Utilities;

    public class Race : IRace
    {
        private string raceName;
        private int laps;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new HashSet<IPilot>();
        }

        public string RaceName
        {
            get => this.raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.laps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot) => this.pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The { this.RaceName} race has:");
            sb.AppendLine($"Participants: {this.Pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");

            if (this.TookPlace)
            {
                sb.AppendLine($"Took place: Yes");
            }
            else
            {
                sb.AppendLine($"Took place: No");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

