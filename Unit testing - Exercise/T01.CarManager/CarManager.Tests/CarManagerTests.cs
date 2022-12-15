namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        //Tests for constructors
        [Test]
        public void ConstructorShouldSetValuesForTheProps()
        {
            string make = "Mercedes";
            string model = "E350d";
            double fuelConsumption = 4.89;
            double fuelCapacity = 60.5;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.FuelAmount == 0, "ConstructorShouldSetValuesForTheProps");
            Assert.That(car.Make == "Mercedes", "ConstructorShouldSetValuesForTheProps");
            Assert.That(car.Model == "E350d", "ConstructorShouldSetValuesForTheProps");
            Assert.That(car.FuelConsumption == 4.89, "ConstructorShouldSetValuesForTheProps");
            Assert.That(car.FuelCapacity == 60.5, "ConstructorShouldSetValuesForTheProps");
        }

        //Tests for setters of the properties
        //Test for the .Make property
        [Test]
        public void TheCarMakeCannotBeNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(null, "a", 2, 2);
                Car car1 = new Car(string.Empty, "a", 2, 2);
            }, "Make cannot be null or empty!");
        }

        //Test for the .Model property
        [Test]
        public void TheCarModelCannotBeNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("a", null, 2, 2);
                Car car1 = new Car("a", String.Empty, 2, 2);
            }, "Make cannot be null or empty!");
        }

        //Test for the .FuelConsumption property
        [Test]
        public void TheCarFuelConsumptionCannotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("a", "b", 0, 1);
                Car car1 = new Car("a", "b", -6, 1);
            }, "Fuel consumption cannot be zero or negative!");
        }

        //Test for the .FuelAmount property
        [Test]
        public void TheFuelCapacityCannotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("a", "b", 1, 0);
                Car car1 = new Car("aa", "bb", 1, -6);
            }, "Fuel capacity cannot be zero or negative!");
        }

        //Tests for the methods
        //Tests for the Refuel() method
        [Test]
        public void RefuelMethodShouldIncreaseTheFuelAmountOfTheCar()
        {
            Car car = new Car("a", "b", 2, 20);
            car.Refuel(16);

            double expectedFuelAmount = 16;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount, "RefuelMethodShouldIncreaseTheFuelAmountOfTheCar");
        }

        [Test]
        public void RefuelMethodShouldThrowExceptionIfTheAmountIsZeroOrNegative()
        {
            Car car = new Car("a", "b", 1, 20);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
                car.Refuel(-8);
            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void RefuelMethodShouldNotRefuelTheFullAmountIfItIsMoreThanTheCapacity()
        {
            Car car = new Car("a", "b", 1, 9);

            car.Refuel(200);

            double expectedFuelAmount = car.FuelCapacity;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        //Tests for the Drive() method
        [Test]
        public void DriveMethodShouldReduceTheFuelAmountByGivenDistance()
        {
            Car car = new Car("a", "b", 10, 40);
            car.Refuel(35);

            car.Drive(20);

            double expectedFuelAmount = 33;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount, "DriveMethodShouldReduceTheFuelAmountByGivenDistance");
        }

        [Test]
        public void NeededFuelForDriveMethodShouldBeLessThanTheFuelCapacity()
        {
            Car car = new Car("a", "b", 10, 10);
            car.Refuel(6);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(100);
            }, "You don't have enough fuel to drive!");
        }
    }
}