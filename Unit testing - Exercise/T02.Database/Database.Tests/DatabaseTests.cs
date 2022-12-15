namespace Database.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    [TestFixture]
    public class DatabaseTests
    {
        //Checking the constructor
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorMustExceedTheElementsInTheDatabase(int[] elements)
        {
            //Arrange
            Database db = new Database(elements);

            //Act
            int[] expectedElements = elements;
            int[] actualElements = db.Fetch();

            int expectedCount = elements.Length;
            int actualCount = db.Count;

            //Assert
            CollectionAssert.AreEqual(expectedElements, actualElements);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void ConstructorMustNotExceedMoreElementsInTheDatabase(int[] elements)
        {
            //Arrange, Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(elements);
            }, "Array's capacity must be exactly 16 integers!");
        }

        //Checking the count getter
        [Test]
        public void CountGetterWorking()
        {
            //Arrange
            Database db = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            //Act
            int expectedCount = 16;
            int actualCount = db.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount, "The count getter isn't working correctly.");
        }

        //Checking the Add() method with valid data
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddingElementsToTheDatabse(int[] elements)
        {
            //Arrange
            Database db = new Database(new int[] { });

            //Act
            foreach (var element in elements)
            {
                db.Add(element);
            }

            int[] expectedElements = elements;
            int[] actualElements = db.Fetch();

            int expectedCount = elements.Length;
            int actualCount = db.Count;

            //Assert
            CollectionAssert.AreEqual(expectedElements, actualElements);
            Assert.AreEqual(expectedCount, actualCount);
        }

        //Checking the Add() method with invalid data
        [Test]
        public void CheckingIfWeTryToAddMoreElementsThanTheCapacity()
        {
            //Arrange
            Database database = new Database(new int[16]);

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                int newElement = 1;
                database.Add(newElement);
            }, "Array's capacity must be exactly 16 integers!");
        }

        //Checking the Remove() method with valid data
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RemovingElementFromTheDatabaseOnce(int[] elements)
        {
            //Arrange
            Database db = new Database(elements);

            //Act
            db.Remove();

            List<int> listOfExpectedElements = new List<int>(elements);
            listOfExpectedElements.RemoveAt(elements.Length - 1);

            int[] expectedElements = listOfExpectedElements.ToArray();
            int[] actualElements = db.Fetch();

            int expectedCount = expectedElements.Length;
            int actualCount = db.Count;

            //Assert
            CollectionAssert.AreEqual(expectedElements, actualElements);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RemovingElementFromTheDatabaseMoreThanOnce(int[] elements)
        {
            //Arrange
            Database db = new Database(elements);

            //Act
            for (int i = 0; i < elements.Length; i++)
            {
                db.Remove();
            }

            int[] expectedElements = new int[] { };
            int[] actualElements = db.Fetch();

            int expectedCount = 0;
            int actualCount = db.Count;

            //Assert
            CollectionAssert.AreEqual(expectedElements, actualElements);
            Assert.AreEqual(expectedCount, actualCount);
        }

        //Checking the Remove() method with invalid data
        [Test]
        public void CheckingIFWeTryToRemoveAnElementFromEmptyDatabase()
        {
            //Arrange
            Database database = new Database(new int[0]);

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "The collection is empty!");
        }

        //Checking the Fetch() method
        [TestCase(new int[] {})]
        [TestCase(new int[1] { 1 })]
        [TestCase(new int[3] {1, 2, 3})]
        [TestCase(new int[16] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void FetchMethodShouldReturnAllOfTheDatabaseElements(int[] elements)
        {
            //Arrange
            Database db = new Database(elements);

            //Act
            int[] expectedElements = elements;
            int[] actualElements = db.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedElements, actualElements, "The Fetch() method isn't working correctly.");
        }
    }
}
