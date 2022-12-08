using System;
namespace PlayersAndMonsters
{
    public class Elf : Hero
    {
        public Elf(string username, int level) : base(username, level)
        {
            this.Username = username;
            this.Level = level;
        }
    }
}

