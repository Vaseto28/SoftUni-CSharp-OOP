namespace Heroes.Models.Map
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using global::Heroes.Models.Heroes;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Barbarian> barbarians = new List<Barbarian>();
            List<Knight> knights = new List<Knight>();

            foreach (var player in players)
            {
                if (player.GetType().Name == typeof(Barbarian).Name && player.IsAlive && player.Weapon != null)
                {
                    barbarians.Add(player as Barbarian);
                }

                if (player.GetType().Name == typeof(Knight).Name && player.IsAlive && player.Weapon != null)
                {
                    knights.Add(player as Knight);
                }
            }

            int knightsCountAtTheBeggining = knights.Count;
            int barbariansCountAtTheBeggining = barbarians.Count;
            while (true)
            {
                foreach (var knight in knights.Where(x => x.IsAlive))
                {
                    foreach (var barbarian in barbarians.Where(x => x.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var barbarian in barbarians.Where(x => x.IsAlive))
                {
                    foreach (var knight in knights.Where(x => x.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }

                knights = knights.Where(x => x.IsAlive).ToList();
                barbarians = barbarians.Where(x => x.IsAlive).ToList();

                if (!barbarians.Any(x => x.IsAlive))
                {
                    return $"The knights took {knightsCountAtTheBeggining - knights.Count} casualties but won the battle.";
                }

                if (!knights.Any(x => x.IsAlive))
                {
                    return $"The barbarians took {barbariansCountAtTheBeggining - barbarians.Count} casualties but won the battle.";
                }
            }
        }
    }
}

