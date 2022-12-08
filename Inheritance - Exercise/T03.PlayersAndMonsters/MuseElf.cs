using System;
namespace PlayersAndMonsters
{
    public class MuseElf : Elf
    {
        public MuseElf(string username, int level) : base(username, level)
        {
            this.Username = username;
            this.Level = level;
        }
    }
}

