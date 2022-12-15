namespace DatabaseExtended.Tests
{
    using System;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        //Tests for Constructor
        [Test]
        public void ConstructorShouldFillTheDatabase()
        {
            Database db = new Database(new Person(3271843, "Antoniya"), new Person(32434, "Vasil"));

            Assert.That(db.Count == 2, "ConstructorShouldFillTheDatabase");
        }

        //Tests for AddRange() method
        [Test]
        public void AddRangeMethodShouldAddArrayOfPeopleIntoTheDatabase()
        {
            Person[] people = new Person[]
            {
                new Person(32323, "Antoniya"),
                new Person(32534, "Vasil")
            };

            Database db = new Database(people);

            Assert.That(db.Count == 2, "AddRangeMethodShouldAddArrayOfPeopleIntoTheDatabase");
        }

        //Tests for Add() method
        [Test]
        public void AddMethodShouldAddThePersonInTheDatabaseIfThereIsCapacity()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"),
                new Person(31232323, "Angelina"));

            Person personToAdd = new Person(318931, "Pesho");

            db.Add(personToAdd);

            int expectedCount = 15;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount, "AddMethodShouldAddThePersonInTheDatabaseIfThereIsCapacity");
        }

        [Test]
        public void AddMethodShouldNotAddPersonToTheDatabaseIfThereIsNoCapacity()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"),
                new Person(34626453456547, "gurtry"),
                new Person(5678567456456, "asdwefwe"),
                new Person(35784567576456, "dfhfghrt"));

            Person personToNotAdd = new Person(23143, "Angel");

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(personToNotAdd);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodShouldNotAddPersonToTheDatabaseIfTheDatabaseContainsHisName()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"));

            Person personNotToAdd = new Person(12342124444, "Gosho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(personNotToAdd);
            }, "There is already user with this username!");
        }

        [Test]
        public void AddMethodShouldNotAddPersonToTheDatabaseIfTheDatabaseContainsHisId()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"));

            Person personNotToAdd = new Person(1242358235, "KKKK");

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(personNotToAdd);
            }, "There is already user with this Id!");
        }

        //Tests for Remove() method
        [Test]
        public void RemoveMethodShouldRemovePersonFromTheDatabase()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"));

            db.Remove();

            int expecteCount = 12;
            int actualCount = db.Count;

            Assert.AreEqual(expecteCount, actualCount, "RemoveMethodShouldRemovePersonFromTheDatabase");
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfTheDatabaseIsEmpty()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        //Tests for FindByUsername() method
        [Test]
        public void FindByUsernameMethodShouldReturnThePersonWithTheCorespondingName()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"));

            Person foundPerson = db.FindByUsername("Gosho");

            long expectedId = 1242358235;
            long actualId = foundPerson.Id;

            Assert.AreEqual(expectedId, actualId, "FindByUsernameMethodShouldReturnThePersonWithTheCorespondingName");
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfTheNameIsNull()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"));

            Assert.Throws<ArgumentNullException>(() =>
            {
                Person notFoundPerson = db.FindByUsername(null);
            }, "Username parameter is null!");
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfDoNotFindThePersonWiththeCorespondingName()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person notFoundPerson = db.FindByUsername("Iliyan");
            }, "No user is present by this username!");
        }

        //Tests for FindById() method
        [Test]
        public void FindByIdMethodShouldReturnThePersonWithTheCorespondingId()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"));

            Person foundPerson = db.FindById(9089078567567457);

            string expectedName = "nm,";
            string actualName = foundPerson.UserName;

            Assert.AreEqual(expectedName, actualName, "FindByIdMethodShouldReturnThePersonWithTheCorespondingId");
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfTheIdIsNegative()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Person notFoundPerson = db.FindById(-24421);
            }, "Id should be a positive number!");
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfDoNotFindThePersonWithTheCorespondingId()
        {
            Database db = new Database(
                new Person(1242358235, "Gosho"),
                new Person(12234234, "asd"),
                new Person(56757435, "Goasdsho"),
                new Person(58678678, "Gowersho"),
                new Person(4565867967967, "fgh"),
                new Person(69678856657, "hjk"),
                new Person(9089078567567457, "nm,"),
                new Person(34534675678, "tyuty"),
                new Person(65856456, "jklgk"),
                new Person(36547546, "fghstrsh"),
                new Person(9774937776, "ghjghj"),
                new Person(56734543656, "sdfsdyt"),
                new Person(678967856674, "adgdew"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person notFoundPerson = db.FindById(1);
            }, "No user is present by this ID!");
        }
    }
}