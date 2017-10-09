namespace _01.Database.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        public Database database;

        //[SetUp]
        //public void CreateEmptyDatabase()
        //{
        //    //Arrange
        //    this.database = new Database(new List<int>());
        //}

        [Test]
        public void ConstructorElementsPropertyInputZeroElementsCollection()
        {
            //Arrange
            var emptyCollection = CreateIntCollection(0);

            //Assert
            Assert.NotNull(new Database(emptyCollection));
        }
        [Test]
        public void ConstructorElementsPropertyInputOneElementsCollection()
        {
            //Arrange
            var oneElementCollection = CreateIntCollection(1);

            //Assert
            Assert.NotNull(new Database(oneElementCollection));
        }
        [Test]
        public void ConstructorElementsPropertyInputMaximumElementsCollection()
        {
            //Arrange
            var maximumElementsCollection = CreateIntCollection(16);
            var testingUnit = new Database(maximumElementsCollection);

            //Assert
            Assert.NotNull(testingUnit);
        }
        [Test]
        public void ConstructorElementsPropertyExceptionInputOvercapacityElementsCollection()
        {
            //Arrange
            var overcapacityElementsCollection = CreateIntCollection(17);

            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(overcapacityElementsCollection));
        }
        [Test]
        public void ConstructorElementsPropertyExceptionInputNullCollection()
        {
            //Arrange
            ICollection<int> nullCollection = null;

            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(nullCollection));
        }

        [Test]
        public void AddElementInEmpyCapacityCollection()
        {
            //Arrgane
            var emptyCollection = CreateIntCollection(0);
            var database = new Database(emptyCollection);

            //Act
            database.Add(5);

            //Assert
            Assert.AreEqual(1, database.Numbers.Count);
        }
        [Test]
        public void AddElementInFullCapacityCollectionException()
        {
            //Arrange
            var fullCollection = CreateIntCollection(16);
            var database = new Database(fullCollection);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => database.Add(5)
                , "Cannot add more elements than capacity.");
        }

        [Test]
        public void RemoveElementFromFullElementsCollection()
        {
            //Arrange
            var fullCollection = CreateIntCollection(16);
            var database = new Database(fullCollection);

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(15, database.Numbers.Count);
        }
        [Test]
        public void RemoveElementFromOneElementCollection()
        {
            //Arrange
            var oneElementCollection = CreateIntCollection(1);
            var database = new Database(oneElementCollection);

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(0, database.Numbers.Count);
        }
        [Test]
        public void RemoveElementFromZeroElementsCollectionExeption()
        {
            //Arrange
            var emptyCollection = CreateIntCollection(0);
            var database = new Database(emptyCollection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchReturnCorrectly()
        {
            //Arrange
            var fullCollection = CreateIntCollection(10);
            var database = new Database(fullCollection);

            //Acrt
            var output = database.Fetch();

            //Assert
            Assert.AreEqual(fullCollection, output);
        }


        private ICollection<int> CreateIntCollection(int count)
        {
            ICollection<int> collection = new List<int>();
            for (int i = 0; i < count; i++)
            {
                collection.Add(i);
            }

            return collection;
        }
    }
}
