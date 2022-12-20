using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void TheCarCounstructorShouldInitializeAnInstanceOfAnObjectCorrectly()
            {
                Car car = new Car("Mercedes", 9);

                string expectedName = "Mercedes";
                string actualName = car.CarModel;

                int expectedProblems = 9;
                int actualProblems = car.NumberOfIssues;

                Assert.AreEqual(expectedName, actualName, "TheCarCounstructorShouldInitializeAnInstanceOfAnObjectCorrectly");
                Assert.AreEqual(expectedProblems, actualProblems, "TheCarCounstructorShouldInitializeAnInstanceOfAnObjectCorrectly");
            }

            [Test]
            public void TheGarageConstructorShouldInitializeAnInstanceOfAnObjectCorrectly()
            {
                Garage garage = new Garage("OOP", 19);

                string expectedName = "OOP";
                string actualName = garage.Name;

                int expectedMechanics = 19;
                int actualMechanics = garage.MechanicsAvailable;

                int expectedCarsCount = 0;
                int actualCarsCount = garage.CarsInGarage;

                Assert.AreEqual(expectedName, actualName, "TheGarageConstructorShouldInitializeAnInstanceOfAnObjectCorrectly");
            }

            [Test]
            public void TheNamePropertyShouldThrowAnExceptionIfItIsNullOrEmpty()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(null, 12);
                }, "Invalid garage name.");

                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(String.Empty, 12);
                }, "Invalid garage name.");
            }

            [Test]
            public void TheMechanicsAvailablePropertyShouldThrowAnExceptionIfItItZeroOrNegative()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("OOP", 0);
                }, "At least one mechanic must work in the garage.");

                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("OOP", -19);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void TheAddCarMethodShouldThrowAnExceptionIfTheGarageIsFull()
            {
                Car car = new Car("OOO", 12);
                Car car1 = new Car("OOOO", 11);
                Garage garage = new Garage("OOP", 1);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car1);
                }, "No mechanic available.");
            }

            [Test]
            public void TheAddMethodShouldAddCarInTheGarageAndIncreaseTheCount()
            {
                Car car = new Car("OOP", 90);
                Car car1 = new Car("LLL", 12);
                Car car2 = new Car("III", 78);
                Garage garage = new Garage("YYY", 12);

                garage.AddCar(car);
                garage.AddCar(car1);
                garage.AddCar(car2);

                int expectedCarsintheGarage = 3;
                int actualCountIntheGarage = garage.CarsInGarage;

                Assert.AreEqual(expectedCarsintheGarage, actualCountIntheGarage, "TheAddMethodShouldAddCarInTheGarageAndIncreaseTheCount");
            }

            [Test]
            public void TheFixMethodShouldThrowAnExceptionIfTheGivenCarIsNotInTheGarage()
            {
                Garage garage = new Garage("OOP", 12);
                string carModel = "Mercedes";

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(carModel);
                }, $"The car {carModel} doesn't exist.");
            }

            [Test]
            public void TheFixCarMethodShouldSetTheGivenCarIssuesToZero()
            {
                Car car = new Car("Mercedes", 9);
                Garage garage = new Garage("OOP", 12);

                garage.AddCar(car);
                garage.FixCar(car.CarModel);

                int expectedIssues = 0;
                int actualIssues = car.NumberOfIssues;

                Assert.AreEqual(expectedIssues, actualIssues, "TheFixCarMethodShouldSetTheGivenCarIssuesToZero");
            }

            [Test]
            public void TheRemoveFixedCarMethodShouldThrowAnExceptionIfThereIsNoFixedCarsAvailable()
            {
                Car car = new Car("Mercedes", 1);
                Garage garage = new Garage("OOP", 12);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, $"No fixed cars available.");
            }

            [Test]
            public void TheRemoveFixedCarMethodShouldRemoveAllFixedCarsInTheGarage()
            {
                Car car = new Car("Mercedes", 10);
                Car car1 = new Car("BMW", 10);
                Car car2 = new Car("Audi", 12);
                Car car3 = new Car("Lada", 110);
                Garage garage = new Garage("OOP", 11);

                garage.AddCar(car);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                garage.FixCar(car.CarModel);
                garage.FixCar(car1.CarModel);
                garage.FixCar(car2.CarModel);

                garage.RemoveFixedCar();

                int expectedCarsInTheGarage = 1;
                int actualCarsInTheGarage = garage.CarsInGarage;

                Assert.AreEqual(expectedCarsInTheGarage, actualCarsInTheGarage, "TheRemoveFixedCarMethodShouldRemoveAllFixedCarsInTheGarage");
            }

            [Test]
            public void TheReportMethodShouldReturnCorrectMessage()
            {
                Car car = new Car("Mercedes", 10);
                Car car1 = new Car("BMW", 10);
                Car car2 = new Car("Audi", 12);
                Car car3 = new Car("Lada", 110);
                Garage garage = new Garage("OOP", 11);

                garage.AddCar(car);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                List<string> expectedCarModels = new List<string> { car.CarModel, car1.CarModel, car2.CarModel, car3.CarModel };
                string expectedMessage = $"There are {expectedCarModels.Count} which are not fixed: {String.Join(", ", expectedCarModels)}.";
                string actualMessage = garage.Report();

                Assert.AreEqual(expectedMessage, actualMessage, "theReportMethodShouldReturnCorrectMessage");
            }
        }
    }
}