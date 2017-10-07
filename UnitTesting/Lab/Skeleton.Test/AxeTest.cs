namespace Skeleton.Test
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTest
    {
        private const int AxeAtack = 1;
        private const int AxeDurability = 1;
        private const int DummyHealth = 10;
        private const int DummyExperience = 5;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInitialize()
        {
            //Arange
            this.axe = new Axe(AxeAtack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

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
            //Act
            this.axe.Attack(dummy);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
        }

        [Test]
        public void AtackWithBrokenAxeExceptionMessage()
        {
            //Act
            this.axe.Attack(dummy);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
            Assert.AreEqual("Axe is broken.", ex.Message);
        }
    }
}
