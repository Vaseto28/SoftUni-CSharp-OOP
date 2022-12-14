namespace T03.Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name, int power) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"Rogue - {this.Name} hit for {this.Power} damage";
        }
    }
}

