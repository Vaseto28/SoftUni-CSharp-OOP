using System;
namespace PlayersAndMonsters
{
    public class DarkWizard : Wizard
    {
        public DarkWizard(string username, int level) : base(username, level)
        {
            this.Username = username;
            this.Level = level;
        }
    }
}

