namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;
    using FightingArena;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        //Test for the constructor
        [Test]
        public void ConstructorShouldInitializeTheWarrior()
        {
            Warrior warrior = new Warrior("Angel", 20, 400);

            Assert.That(warrior.Name == "Angel", "ConstructorShouldInitializeTheWarrior");
            Assert.That(warrior.Damage == 20, "ConstructorShouldInitializeTheWarrior");
            Assert.That(warrior.HP == 400, "ConstructorShouldInitializeTheWarrior");
        }

        //Test for the .Name property
        [Test]
        public void NamePropertyCannotBeNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(null, 2, 2);
                Warrior warrior1 = new Warrior(" ", 2, 5);
            }, "Name should not be empty or whitespace!");
        }

        [Test]
        public void NameGetterShouldReturnTheCorrectValue()
        {
            Warrior warrior = new Warrior("NNN", 20, 20);

            string expectedName = "NNN";
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName, "NameGetterShouldReturnTheCorrectValue");
        }

        //Tests for the .Damage property
        [Test]
        public void DamagePropertyCannotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Name", 0, 20);
                Warrior warrior1 = new Warrior("name1", -20, 20);
            }, "Damage value should be positive!");
        }

        [Test]
        public void DamageGetterShouldReturnCorrectValue()
        {
            Warrior warrior = new Warrior("NNN", 20, 20);

            int expectedDamage = 20;
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage, "NameGetterShouldReturnTheCorrectValue");
        }

        //Tests for the .HP property
        [Test]
        public void HPPropertyCannotBeNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("name", 20, -20);
            }, "HP should not be negative!");
        }

        [Test]
        public void HPGetterShouldReturnTheCorrectValue()
        {
            Warrior warrior = new Warrior("NNN", 20, 20);

            int expectedHP = 20;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedHP, actualHp, "NameGetterShouldReturnTheCorrectValue");
        }

        //Tests for the Attack() method
        [Test]
        public void YourHPMustBeMoreThanMIN_ATTACK_HP()
        {
            Warrior attacker = new Warrior("Attacker", 200, 26);
            Warrior defender = new Warrior("Defender", 20, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void TheHPOfYourOppenentMustBeMoreThanMIN_ATTACK_HP()
        {
            Warrior attacker = new Warrior("Attacker", 200, 96);
            Warrior defender = new Warrior("Defender", 20, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [Test]
        public void YourHPMustBeMoreThanTheDamageOfYourOpponent()
        {
            Warrior attacker = new Warrior("Attacker", 20, 96);
            Warrior defender = new Warrior("Defender", 200, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, $"You are trying to attack too strong enemy");
        }

        [Test]
        public void AttackMethodShouldReduceYourHPByTheDefenderDamage()
        {
            Warrior attacker = new Warrior("Attacker", 20, 96);
            Warrior defender = new Warrior("Defender", 20, 70);

            attacker.Attack(defender);

            int expectedHP = 76;
            int actualHP = attacker.HP;

            Assert.AreEqual(expectedHP, actualHP, "AttackMethodShouldReduceYourHPByTheDefenderDamage");
        }

        [Test]
        public void AttackMethodShouldKillTheDefenderIfHisHPIsLessThanTheDamageOfTheAttacker()
        {
            Warrior attacker = new Warrior("Attacker", 200, 96);
            Warrior defender = new Warrior("Defender", 20, 70);

            attacker.Attack(defender);

            int expectedDefenderHP = 0;
            int actualDefenderHp = defender.HP;

            Assert.AreEqual(expectedDefenderHP, actualDefenderHp, "AttackMethodShouldKillTheDefenderIfHisHPIsLessThanTheDamageOfTheAttacker");
        }

        [Test]
        public void AttackMethodShouldReduceTheHPOfTheDefenderIfTheDamagaOfAttackerIsLessThanTheHPOfTheDefender()
        {
            Warrior attacker = new Warrior("Attacker", 43, 96);
            Warrior defender = new Warrior("Defender", 20, 70);

            attacker.Attack(defender);

            int expectedDefenderHP = 27;
            int actualDefenderHp = defender.HP;

            Assert.AreEqual(expectedDefenderHP, actualDefenderHp, "AttackMethodShouldReduceTheHPOfTheDefenderIfTheDamagaOfAttackerIsLessThanTheHPOfTheDefender");
        }
    }
}