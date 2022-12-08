using System;
namespace PlayersAndMonsters
{
    public class SoulMaster : DarkWizard
    {
        public SoulMaster(string username, int level) : base(username, level)
        {
            this.Username = username;
            this.Level = level;
        }
    }
}

