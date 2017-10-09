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
            var emptyCollection = new List<Person>();

            //Assert
            Assert.NotNull(new Database(emptyCollection));
        }
        [Test]
        public void ConstructorElementsPropertyInputOneElementsCollection()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("123", "John") };

            //Assert
            Assert.NotNull(new Database(oneElementCollection));
        }
        [Test]
        public void ConstructorElementsPropertyInputNullCollection()
        {
            //Arrange
            ICollection<Person> nullCollection = null;

            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(nullCollection));
        }

        [Test]
        public void AddElementInEmpyCapacityCollection()
        {
            //Arrgane
            var emptyCollection = new List<Person>();
            var database = new Database(emptyCollection);

            //Act
            database.Add(new Person("123", "John"));

            //Assert
            Assert.AreEqual(1, database.Persons.Count);
        }
        [Test]
        public void AddElementInFullCapacityCollection()
        {
            //Arrange
            var fullCollection = CreatePersonCollection(16);
            var database = new Database(fullCollection);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person("123", "John"))
                , "Cannot add more elements than capacity.");
        }
        [Test]
        public void AddElementWithAlreadyExistingUsername()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("123", "John") };
            var database = new Database(oneElementCollection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person("890", "John")));
        }
        [Test]
        public void AddElementWithAlreadyExistingId()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("123", "John") };
            var database = new Database(oneElementCollection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person("123", "Michael")));
        }

        [Test]
        public void RemoveElementFromFullElementsCollection()
        {
            //Arrange
            var fullCollection = CreatePersonCollection(16);
            var database = new Database(fullCollection);

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(15, database.Persons.Count);
        }
        [Test]
        public void RemoveElementFromOneElementCollection()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("123", "John") };
            var database = new Database(oneElementCollection);

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(0, database.Persons.Count);
        }
        [Test]
        public void RemoveElementFromZeroElementsCollection()
        {
            //Arrange
            var emptyCollection = new List<Person>();
            var database = new Database(emptyCollection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindElementByUsername()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("547", "Richard") };
            var inputPerson = new Person("123", "John");
            var database = new Database(oneElementCollection);

            //Act
            database.Add(inputPerson);
            var findedPerson = database.FindByUsername("John");

            //Assert
            Assert.AreEqual(inputPerson, findedPerson);
        }
        [Test]
        public void FindUnexistingElementByUsername()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("547", "Richard") };
            var database = new Database(oneElementCollection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Michael"));
        }
        [Test]
        public void FindNullElementByUsername()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("547", "Charles") };
            var database = new Database(oneElementCollection);

            //Assert
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void FindElementById()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("547", "Richard") };
            var database = new Database(oneElementCollection);
            var inputPerson = new Person("123", "John");

            //Act
            database.Add(inputPerson);
            var findedPerson = database.FindById("123");

            //Assert
            Assert.AreEqual(inputPerson, findedPerson);
        }
        [Test]
        public void FindUnexistingElementById()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("547", "Richard") };
            var database = new Database(oneElementCollection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindById("08384"));
        }
        [Test]
        public void FindNullElementById()
        {
            //Arrange
            var oneElementCollection = new List<Person>() { new Person("547", "Charles") };
            var database = new Database(oneElementCollection);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById("-573"));
        }


        private ICollection<Person> CreatePersonCollection(int count)
        {
            var collection = new List<Person>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var username = "John" + random.Next(1, 1000000);
                var id = "0000" + random.Next(1, 1000000);

                var person = new Person(username, id);
                collection.Add(person);
            }

            return collection;
        }
    }
}
