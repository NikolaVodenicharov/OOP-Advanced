
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTest
    {
        [Test]
        public void AxeLosesDurabilityAfterAtack()
        {
            //Arange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 18);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(9, axe.DurabilityPoints);
        }

        [Test]
        public void AtackWithBrokenAxeThrowException()
        {
            //Arange
            Axe axe = new Axe(1, 1);
            Dummy dummy = new Dummy(20, 8);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }

        [Test]
        public void AtackWithBrokenAxeExceptionMessage()
        {
            //Arange
            Axe axe = new Axe(1, 1);
            Dummy dummy = new Dummy(20, 8);

            //Act
            axe.Attack(dummy);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.AreEqual("Axe is broken.", ex.Message);
        }
    }

