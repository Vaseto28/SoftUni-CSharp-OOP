using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void TheConstructorOfTheWeaponClassShouldInitializeAnInstanceOfAnObjectCorrectly()
            {
                Weapon weapon = new Weapon("LLL", 80, 222);

                string expectedName = "LLL";
                string actualName = weapon.Name;

                double expectedPrice = 80;
                double actualPrice = weapon.Price;

                int expectedDestructionLevel = 222;
                int actualDestructionLevel = weapon.DestructionLevel;

                Assert.AreEqual(expectedName, actualName, "TheConstructorOfTheWeaponClassShouldInitializeAnInstanceOfAnObjectCorrectly");
                Assert.AreEqual(expectedPrice, actualPrice, "TheConstructorOfTheWeaponClassShouldInitializeAnInstanceOfAnObjectCorrectly");
                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel, "TheConstructorOfTheWeaponClassShouldInitializeAnInstanceOfAnObjectCorrectly");
            }

            [Test]
            public void TheWeaponPriceCannotBeNegative()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("LLL", -9929, 23);
                }, "Price cannot be negative.");
            }

            [Test]
            public void TheIncreaseDestructionLevelMethodShouldIncreaseTheDestructionLevelByOne()
            {
                Weapon weapon = new Weapon("OOP", 9, 8);

                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();

                int expectedValue = 12;
                int actualValue = weapon.DestructionLevel;

                Assert.AreEqual(expectedValue, actualValue, "TheIncreaseDestructionLevelMethodShouldIncreaseTheDestructionLevelByOne");
            }

            [Test]
            public void TheIsNuclearPropertyShouldReturnTrueIfTheDestructionLevelIsGraterThanTwentyOrFalseIfItIsSmallerThaTwenty()
            {
                Weapon weapon = new Weapon("OOP", 9, 80);

                Assert.That(weapon.IsNuclear == true, "TheIsNuclearPropertyShouldReturnTrueIfTheDestructionLevelIsGraterThanTwentyOrFalseIfItIsSmallerThaTwenty");

                Weapon weapon1 = new Weapon("OOP", 8, 1);

                Assert.That(weapon1.IsNuclear == false, "TheIsNuclearPropertyShouldReturnTrueIfTheDestructionLevelIsGraterThanTwentyOrFalseIfItIsSmallerThaTwenty");
            }

            [Test]
            public void TheConstructorShouldInitializeAnInstanceOfAnObjectCorrectly()
            {
                Planet planet = new Planet("OOP", 43);

                string expectedName = "OOP";
                string actualName = planet.Name;

                double expectedBudget = 43;
                double actualBudget = planet.Budget;

                Assert.AreEqual(expectedName, actualName, "TheConstructorShouldInitializeAnInstanceOfAnObjectCorrectly");
                Assert.AreEqual(expectedBudget, actualBudget, "TheConstructorShouldInitializeAnInstanceOfAnObjectCorrectly");
            }

            [Test]
            public void TheNamePropertyShouldThrowAnExceptionIfItIsNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(null, 20);
                }, "Invalid planet Name");

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(string.Empty, 90);
                }, "Invalid planet Name");
            }

            [Test]
            public void TheBudgetPropertyShouldThrowAnExceptionIfItIsNegative()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("OOP", -90);
                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void TheAddWeaponMethodShouldAddWeaponsToTheWeaponsProperty()
            {
                Weapon weapon = new Weapon("Kae", 23, 45);
                Weapon weapon1 = new Weapon("OOP", 90, 333);
                Planet planet = new Planet("PPP", 11110);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                IReadOnlyCollection<Weapon> expectedWeapons = new List<Weapon>
                {
                    weapon,
                    weapon1
                };

                IReadOnlyCollection<Weapon> actualWeapons = planet.Weapons;

                CollectionAssert.AreEqual(expectedWeapons, actualWeapons, "TheAddWeaponMethodShouldAddWeaponsToTheWeaponsProperty");
            }

            [Test]
            public void TheMilitaryPowerRatioShouldBeCalculatedCorrect()
            {
                Weapon weapon = new Weapon("Kae", 23, 45);
                Weapon weapon1 = new Weapon("OOP", 90, 333);
                Planet planet = new Planet("PPP", 11110);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                double expectedValue = 378;
                double actualValue = planet.MilitaryPowerRatio;

                Assert.AreEqual(expectedValue, actualValue, "TheMilitaryPowerRatioShouldBeCalculatedCorrect");
            }

            [Test]
            public void TheProfitMethodShouldIncreaseTheBudgetWithTheGivenAmount()
            {
                Planet planet = new Planet("PPP", 11);

                planet.Profit(22);

                double expectedValue = 33;
                double actualValue = planet.Budget;

                Assert.AreEqual(expectedValue, actualValue, "TheProfitMessageShouldIncreaseTheBudgetWithTheGivenAmount");
            }

            [Test]
            public void TheSpendFundsMethodShouldThrowAnExceptionIfTheGivenAmountIsGraterThanTheCurrentBudget()
            {
                Planet planet = new Planet("PPP", 11);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(33);
                }, $"Not enough funds to finalize the deal.");
            }

            [Test]
            public void TheSpendMethodShouldDecreaseTheBudgetIfTheGivenAmountIsSmallerThanTheBudget()
            {
                Planet planet = new Planet("PPP", 80);

                planet.SpendFunds(77);

                double expectedValue = 3;
                double actualValue = planet.Budget;

                Assert.AreEqual(expectedValue, actualValue, "TheSpendMethodShouldDecreaseTheBudgetIfTheGivenAmountIsSmallerThanTheBudget");
            }

            [Test]
            public void TheAddWeaponMethodShouldThrowAnExceptionIfThePlanetAlreadyContainsTheNameOfTheGivenWeapon()
            {
                Weapon weapon = new Weapon("Kae", 23, 45);
                Weapon weapon1 = new Weapon("OOP", 90, 333);
                Planet planet = new Planet("PPP", 11110);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                Weapon weapon2 = new Weapon("OOP", 22, 90);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon2);
                }, $"There is already a {weapon2.Name} weapon.");
            }

            [Test]
            public void TheRemoveWeaponShouldRemoveTheWeaponWithTheGivenName()
            {
                Weapon weapon = new Weapon("Kae", 23, 45);
                Weapon weapon1 = new Weapon("OOP", 90, 333);
                Weapon weapon2 = new Weapon("OOO", 80, 9);
                Planet planet = new Planet("PPP", 11110);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.RemoveWeapon(weapon.Name);

                int expectedWeaponsCount = 2;
                int actualWeaponsCount = planet.Weapons.Count;

                IReadOnlyCollection<Weapon> expectedWeapons = new List<Weapon> { weapon1, weapon2 };
                IReadOnlyCollection<Weapon> actualWeapons = planet.Weapons;

                Assert.AreEqual(expectedWeaponsCount, actualWeaponsCount, "TheRemoveWeaponShouldRemoveTheWeaponWithTheGivenName");
                CollectionAssert.AreEqual(expectedWeapons, actualWeapons, "TheRemoveWeaponShouldRemoveTheWeaponWithTheGivenName");
            }

            [Test]
            public void TheUpgradeWeaponMethodShouldThrowAnExceptionIfTheWeaponWithTheGivenNameDoesNotExist()
            {
                Planet planet = new Planet("OOP", 90);
                string name = "Pesho";

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(name);
                }, $"{name} does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void TheUpgradeWeaponMethodShouldInvokeTheIncreaseDestructionWeaponIfThereIsAWeaponWithTheGivenName()
            {
                Weapon weapon = new Weapon("Kae", 23, 45);
                Planet planet = new Planet("PPP", 11110);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);

                int expectedValue = 46;
                int actualValue = weapon.DestructionLevel;

                Assert.AreEqual(expectedValue, actualValue, "TheUpgradeWeaponMethodShouldInvokeTheIncreaseDestructionWeaponIfThereIsAWeaponWithTheGivenName");
            }

            [Test]
            public void TheDestructOpponentMethodShouldThrowAnExceptionIfTheMilitaryPowerRatioOfTheOfTheOpponentIsGraterThanTheAttackers()
            {
                Weapon weapon1 = new Weapon("KKKK", 3, 90);
                Planet planet = new Planet("PPO", 300);
                planet.AddWeapon(weapon1);

                Weapon weapon = new Weapon("KKK", 5, 400);
                Planet planet1 = new Planet("OOP", 800);
                planet1.AddWeapon(weapon);


                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planet1);
                }, $"{planet1.Name} is too strong to declare war to!");
            }

            [Test]
            public void TheDestructOpponentMethodShouldReturnCorrectMessage()
            {
                Weapon weapon = new Weapon("KKK", 5, 400);
                Planet planet = new Planet("PPO", 300);
                planet.AddWeapon(weapon);

                Planet planet1 = new Planet("OOP", 800);
                Weapon weapon1 = new Weapon("KKKK", 3, 90);
                planet1.AddWeapon(weapon1);

                string expectedMessage = $"{planet1.Name} is destructed!";
                string actualMessage = planet.DestructOpponent(planet1);

                Assert.AreEqual(expectedMessage, actualMessage, "TheDestructOpponentMethodShouldReturnCorrectMessage");
            }
        }
    }
}
