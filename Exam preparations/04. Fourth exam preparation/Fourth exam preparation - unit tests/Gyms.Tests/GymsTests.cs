using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void TheConstructorShouldInitializeTheObjectWithCorrectValues()
        {
            Gym gym = new Gym("Greg", 30);

            string expectedName = "Greg";
            string actualName = gym.Name;

            int expectedSize = 30;
            int actualSize = gym.Capacity;

            Assert.AreEqual(expectedName, actualName, "TheConstructorShouldInitializeTheObjectWithCorrectValues");
            Assert.AreEqual(expectedSize, actualSize, "TheConstructorShouldInitializeTheObjectWithCorrectValues");
        }

        [Test]
        public void TheNamePropertyShouldThrowAnExceptionIfItIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null, 20);
            }, "Invalid gym name.");
        }

        [Test]
        public void TheNamePropertyShouldThrowAnExceptionIfItIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(String.Empty, 90);
            }, "Invalid gym name.");
        }

        [Test]
        public void TheCapacityPropertyShouldThrowAnExceptionIfItIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("KKK", -9);
            }, "Invalid gym capacity.");
        }

        [Test]
        public void TheCountPropertyShouldReturnCorrectValue()
        {
            Athlete athlete = new Athlete("KKKKKK");
            Athlete athlete1 = new Athlete("KK");
            Gym gym = new Gym("III", 40);

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            int expectedCount = 2;
            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount, "TheCountPropertyShouldReturnCorrectValue");
        }

        [Test]
        public void TheAddAthleteMethodShouldThrowAnExceptionIfTheGymIsFull()
        {
            Athlete athlete = new Athlete("KK");
            Athlete athlete1 = new Athlete("OO");
            Gym gym = new Gym("PP", 1);

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete1);
            }, "The gym is full.");
        }

        [Test]
        public void TheAddAthleteMethodShouldAddAthleteToTheGym()
        {
            Athlete athlete = new Athlete("OO");
            Athlete athlete1 = new Athlete("LL");
            Gym gym = new Gym("JJ", 90);

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            int expectedCount = 2;
            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount, "TheAddAthleteMethodShouldAddAthleteToTheGym");
        }

        [Test]
        public void TheRemoveAthleteMethodShouldThrowAnExceptionIfTheGivenAthleteDoesNotExist()
        {
            Gym gym = new Gym("KK", 90);
            string fullName = "LLL";

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(fullName);
            }, $"The athlete {fullName} doesn't exist.");
        }

        [Test]
        public void TheRemoveAthleteMethodShouldRemoveTheGivenAthleteFromTheGym()
        {
            Athlete athlete = new Athlete("LL");
            Gym gym = new Gym("LLL", 12);

            gym.AddAthlete(athlete);

            gym.RemoveAthlete(athlete.FullName);

            int expectedCount = 0;
            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount, "TheRemoveAthleteMethodShouldRemoveTheGivenAthleteFromTheGym");
        }

        [Test]
        public void TheInjureAthleteMethodShouldThrowAnExceptionIfTheGivenAthleteDoesNotExist()
        {
            Gym gym = new Gym("KKK", 33);
            string fullName = "LLL";

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete(fullName);
            }, $"The athlete {fullName} doesn't exist.");
        }

        [Test]
        public void TheInjureAthleteMethodShouldInjureTheGivenAthlete()
        {
            Athlete athlete = new Athlete("OOP");
            Gym gym = new Gym("KKK", 90);

            gym.AddAthlete(athlete);
            gym.InjureAthlete(athlete.FullName);

            bool expectedInjure = true;
            bool actualInjure = athlete.IsInjured;

            Assert.AreEqual(expectedInjure, actualInjure, "TheInjureAthleteMethodShouldInjureTheGivenAthlete");
        }

        [Test]
        public void TheReportMethodShouldReturnTheCorrectString()
        {
            Athlete athlete = new Athlete("Pesho");
            Athlete athlete1 = new Athlete("Gosho");
            Gym gym = new Gym("Greg", 90);

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            gym.RemoveAthlete(athlete1.FullName);

            string expectedValue = $"Active athletes at Greg: Pesho";
            string actualValue = gym.Report();

            Assert.AreEqual(expectedValue, actualValue, "TheReportMethodShouldReturnTheCorrectString");
        }
    }
}
