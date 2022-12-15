
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using FightingArena;

    [TestFixture]
    public class ArenaTests
    {
        //Test for the constructor
        [Test]
        public void TheConstructorShouldInitializeTheArenaCorrectly()
        {
            Arena arena = new Arena();

            CollectionAssert.AreEqual(new List<Warrior>(), arena.Warriors, "TheConstructorShouldInitializeTheArenaCorrectly");
        }

        //Test for the .Count property
        //We assume that the Enroll() method is working correctly!
        [Test]
        public void TheCountPropertyShouldReturnCorrectValue()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Pesho", 20, 60);
            Warrior warrior1 = new Warrior("Gosho", 30, 400);

            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            int expectedCount = 2;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount, "TheCountPropertyShouldReturnCorrectValue");
        }

        //Tests for Enroll() method
        [Test]
        public void EnrollMethodShouldAddAWarriorInTheCollection()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Pesho", 20, 40);
            Warrior warrior1 = new Warrior("Gosho", 20, 80);

            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            int expectedCount = 2;
            int actualCount = arena.Count;

            List<Warrior> expectedWarriors = new List<Warrior>
            {
                new Warrior("Pesho", 20, 40),
                new Warrior("Gosho", 20, 80)
            };

            List<Warrior> actualWarriors = arena.Warriors.ToList();

            CollectionAssert.AreEqual(expectedWarriors, actualWarriors, "EnrollMethodShouldAddAWarriorInTheCollection");
            Assert.AreEqual(expectedCount, actualCount, "EnrollMethodShouldAddAWarriorInTheCollection");
        }

        [Test]
        public void EnrollMethodMustNotAddTheWarriorIfTheCollectionContainsWarriorWithTheSameName()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Pesho", 20, 60);

            arena.Enroll(warrior);

            Warrior warriorToNotAdd = new Warrior("Pesho", 80, 90);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warriorToNotAdd);
            }, "Warrior is already enrolled for the fights!");
        }

        //Tests for the Fight() method
        [Test]
        public void InFightMethodAttackerShouldAttackTheDefender()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Pesho", 20, 100);
            Warrior defender = new Warrior("Angel", 30, 90);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Pesho", "Angel");

            int expectedAttackerHP = 70;
            int actualAttackerHP = attacker.HP;

            int expectedDefenderHp = 70;
            int actualDefenderHP = defender.HP;

            Assert.AreEqual(expectedAttackerHP, actualAttackerHP, "InFightMethodAttackerShouldAttackTheDefender");
            Assert.AreEqual(expectedDefenderHp, actualDefenderHP, "InFightMethodAttackerShouldAttackTheDefender");
        }

        [Test]
        public void InFightMethodAttackerCannotBeNull()
        {
            Arena arena = new Arena();
            Warrior defender = new Warrior("Angel", 30, 90);

            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "Angel");
            }, $"There is no fighter with name Pesho enrolled for the fights!");
        }

        [Test]
        public void InFightMethodDefenderCannotBeNull()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Pesho", 30, 90);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "Angel");
            }, $"There is no fighter with name Angel enrolled for the fights!");
        }
    }
