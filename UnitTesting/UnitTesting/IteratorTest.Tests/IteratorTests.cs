namespace IteratorTest.Tests
{
    using System;
    using _03.IteratorTest;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class IteratorTests
    {
        /*
        Naming:
            MethodName_StateUnderTest_ExpectedBehavior
        
        Expamples:
            isAdult_AgeLessThan18_False
            withdrawMoney_InvalidAccount_ExceptionThrown
            admitStudent_MissingMandatoryFields_FailToAdmit
        */

        [Test]
        public void ElementsProperty_NullCollection_ThrowException()
        {
            //Arrange
            IList<string> nullCollection = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => new ListIterator(nullCollection));
        }
        [Test]
        public void ElementsProperty_NotNullCollection_AcceptIt()
        {
            //Arrange
            var stateUnderTest = new string[] { "George", "Michlael", "William" };
            var listIterator = new ListIterator(stateUnderTest);

            //Assert
            Assert.AreEqual(stateUnderTest, listIterator.Elements);
        }
        [Test]
        public void ElementsProperty_EmptyCollection_AcceptIt()
        {
            //Arrange
            var stateUnderTest = new List<string>();
            var listIterator = new ListIterator(stateUnderTest);

            //Assert
            Assert.IsNotNull(listIterator);
        }

        [Test]
        public void HasNext_NoMoreElements_False()
        {
            //Arrange
            var emptyCollection = new List<string>();
            var listIterator = new ListIterator(emptyCollection);

            //Act
            var stateUnderTest = listIterator.HasNext();

            //Assert
            Assert.IsFalse(stateUnderTest);
        }
        [Test]
        public void HasNext_HaveMoreElements_True()
        {
            //Arrange
            var collection = new List<string>() { "Joseph", "Charles" };
            var listIterator = new ListIterator(collection);

            //Act
            var stateUnderTest = listIterator.HasNext();

            //Assert
            Assert.IsTrue(stateUnderTest);
        }

        [Test]
        public void Move_NoMoreElements_False()
        {
            //Arrange
            var collection = new List<string>() { "Joseph", "Charles" };
            var listIterator = new ListIterator(collection);

            //Act
            listIterator.Move();
            var stateUnderTest = listIterator.Move();

            //Assert
            Assert.IsFalse(stateUnderTest);
        }
        [Test]
        public void Move_HaveMoreElements_True()
        {
            //Arrange
            var collection = new List<string>() { "Joseph", "Charles" };
            var listIterator = new ListIterator(collection);

            //Act
            var stateUnderTest = listIterator.Move();

            //Assert
            Assert.IsTrue(stateUnderTest);
        }

        [Test]
        public void Print_NoElements_ThrowException()
        {
            //Arrange
            var emptyCollection = new List<string>();
            var listIterator = new ListIterator(emptyCollection);

            //Assert
            Assert.Throws<InvalidOperationException>(() => listIterator.Print());
        }
        [Test]
        public void Print_ExistingElements_ReturnElement()
        {
            //Arrange
            var collection = new List<string>() { "Joseph", "Charles" };
            var listIterator = new ListIterator(collection);

            //Act
            var stateUnderTest = listIterator.Print();

            //Assert
            Assert.AreEqual("Joseph", stateUnderTest);
        }
    }
}
