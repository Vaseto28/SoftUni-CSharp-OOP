using System;
namespace T03.Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name, int power) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"Druid - {this.Name} healed for {this.Power}";
        }
    }
}

