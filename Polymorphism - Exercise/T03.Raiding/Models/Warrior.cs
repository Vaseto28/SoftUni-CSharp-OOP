using System;
namespace T03.Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name, int power) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"Warrior - {this.Name} hit for {this.Power} damage";
        }
    }
}

