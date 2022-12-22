using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void TheConstructorShouldInitializeTheShopCorrectly()
        {
            Shop shop = new Shop(10);

            int expectedCapacity = 10;
            int actualCapacity = shop.Capacity;

            int expectedCount = 0;
            int actualCount = shop.Count;

            Assert.AreEqual(expectedCapacity, actualCapacity, "TheConstructorShouldInitializeTheShopCorrectly");
            Assert.AreEqual(expectedCount, actualCount, "TheConstructorShouldInitializeTheShopCorrectly");
        }

        [Test]
        public void IfTheCapacityIsBelowZeroThePropertyShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-2);
            }, "Invalid capacity.");
        }

        [Test]
        public void TheCountPropertyShouldReturnTheCaountOfPhonesInTheShop()
        {
            Smartphone smartphone = new Smartphone("Samsung", 100);
            Smartphone smartphone1 = new Smartphone("Apple", 100);
            Shop shop = new Shop(10);

            shop.Add(smartphone);
            shop.Add(smartphone1);

            int expectedCount = 2;
            int actualCount = shop.Count;

            Assert.AreEqual(expectedCount, actualCount, "TheCountPropertyShouldReturnTheCaountOfPhonesInTheShop");
        }

        [Test]
        public void TheAddMethodShouldNotAddAPhoneIfItAlreadyExists()
        {
            Smartphone smartphone = new Smartphone("Apple", 100);
            Smartphone smartphone1 = new Smartphone("Apple", 99);
            Shop shop = new Shop(20);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone1);
            }, $"The phone model {smartphone1.ModelName} already exist.");
        }

        [Test]
        public void TheAddMethodShouldThrowExceptionIfTheShopIsFull()
        {
            Smartphone smartphone = new Smartphone("Apple", 100);
            Smartphone smartphone1 = new Smartphone("Samsung", 100);
            Smartphone smartphone2 = new Smartphone("Huawei", 99);
            Shop shop = new Shop(2);

            shop.Add(smartphone);
            shop.Add(smartphone1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone2);
            }, "The shop is full.");
        }

        [Test]
        public void TheAddMethodShouldAddThePhoneInTheSHopIfItIsValidAndTheShopIsNotFull()
        {
            Smartphone smartphone = new Smartphone("Samsung", 100);
            Smartphone smartphone1 = new Smartphone("Apple", 100);
            Smartphone smartphone2 = new Smartphone("Xiomi", 99);
            Shop shop = new Shop(20);

            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.Add(smartphone2);

            int expectedCount = 3;
            int actualCount = shop.Count;

            Assert.AreEqual(expectedCount, actualCount, "TheAddMethodShouldAddThePhoneInTheSHopIfItIsValidAndTheShopIsNotFull");
        }

        [Test]
        public void TheRemoveMethodShouldThrowAnExceptionIfThePhoneDoesNotExist()
        {
            Shop shop = new Shop(10);
            string modelName = "Apple";

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(modelName);
            }, $"The phone model {modelName} doesn't exist.");
        }

        [Test]
        public void TheRemoveMethodShouldRemoveAPhoneFromTheStoreIfSuchExists()
        {
            Smartphone smartphone = new Smartphone("Apple", 100);
            Shop shop = new Shop(10);

            shop.Add(smartphone);
            shop.Remove(smartphone.ModelName);

            int expectedCount = 0;
            int actualCount = shop.Count;

            Assert.AreEqual(expectedCount, actualCount, "TheRemoveMethodShouldRemoveAPhoneFromTheStoreIfSuchExists");
        }

        [Test]
        public void TheTestPhoneMethodShouldThrowAnExceptionIfThePhoneDoesNotExist()
        {
            Shop shop = new Shop(10);
            string modelName = "Apple";
            int batteryUsage = 30;

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, batteryUsage);
            }, $"The phone model {modelName} doesn't exist.");
        }

        [Test]
        public void TheTestPhoneMethodShouldThrowAnExceptionIfThePhoneBatteryIsLessThanTheBatteryUsageForTheTest()
        {
            Smartphone smartphone = new Smartphone("Apple", 20);
            Shop shop = new Shop(20);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(smartphone.ModelName, 40);
            }, $"The phone model {smartphone.ModelName} is low on batery.");
        }

        [Test]
        public void TheTestMethodShouldReduceThePhoneBatteryBecauseOfTheTests()
        {
            Smartphone smartphone = new Smartphone("Samsung", 100);
            Shop shop = new Shop(20);

            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, 30);

            int expectedBattery = 70;
            int actualBattery = smartphone.CurrentBateryCharge;

            Assert.AreEqual(expectedBattery, actualBattery, "TheTestMethodShouldReduceThePhoneBatteryBecauseOfTheTests");
        }

        [Test]
        public void TheChargePhoneMethodShouldThrowAnExceptionIfThePhoneDoesNotExist()
        {
            Shop shop = new Shop(10);
            string modelName = "Apple";

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(modelName);
            }, $"The phone model {modelName} doesn't exist.");
        }

        [Test]
        public void TheChargePhoneMethodSHouldIncreaseTheBatteryLevelOfThePhone()
        {
            Smartphone smartphone = new Smartphone("Apple", 100);
            Shop shop = new Shop(10);
            smartphone.CurrentBateryCharge = 40;

            shop.Add(smartphone);
            shop.ChargePhone(smartphone.ModelName);

            int expectedBatteryLevel = smartphone.MaximumBatteryCharge;
            int actualBatteryLevel = smartphone.CurrentBateryCharge;

            Assert.AreEqual(expectedBatteryLevel, actualBatteryLevel, "TheChargePhoneMethodSHouldIncreaseTheBatteryLevelOfThePhone");
        }
    }
}