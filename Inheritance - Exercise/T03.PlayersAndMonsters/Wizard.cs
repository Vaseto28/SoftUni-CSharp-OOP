using System;
namespace PlayersAndMonsters
{
    public class Wizard : Hero
    {
        public Wizard(string username, int level) : base(username, level)
        {
            this.Username = username;
            this.Level = level;

        }


    }
}

