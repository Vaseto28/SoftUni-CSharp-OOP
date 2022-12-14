using System;
using System.Collections.Generic;

namespace T03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int heroesCnt = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < heroesCnt; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType == "Druid")
                {
                    Druid druid = new Druid(heroName, 80);
                    heroes.Add(druid);
                }
                else if (heroType == "Paladin")
                {
                    Paladin paladin = new Paladin(heroName, 100);
                    heroes.Add(paladin);
                }
                else if (heroType == "Rogue")
                {
                    Rogue rogue = new Rogue(heroName, 80);
                    heroes.Add(rogue);
                }
                else if (heroType == "Warrior")
                {
                    Warrior warrior = new Warrior(heroName, 100);
                    heroes.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int heroesPower = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                heroesPower += hero.Power;
            }

            if (bossPower > heroesPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}

