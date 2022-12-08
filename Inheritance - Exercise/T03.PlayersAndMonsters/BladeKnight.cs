using System;
namespace PlayersAndMonsters
{
    public class BladeKnight : DarkKnight
    {
        public BladeKnight(string username, int level) : base(username, level)
        {
            this.Username = username;
            this.Level = level;
        }
    }
}

