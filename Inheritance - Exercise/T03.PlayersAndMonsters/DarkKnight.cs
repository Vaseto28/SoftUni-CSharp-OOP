using System;
namespace PlayersAndMonsters
{
    public class DarkKnight : Knight
    {
        public DarkKnight(string username, int level) : base(username, level)
        {
            this.Username = username;
            this.Level = level;
        }
    }
}

