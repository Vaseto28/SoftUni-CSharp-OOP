using System;
namespace PlayersAndMonsters
{
    public class Knight : Hero
    {
        public Knight(string username, int level) : base(username, level)
        {
            this.Username = username;
            this.Level = level;
        }
    }
}

