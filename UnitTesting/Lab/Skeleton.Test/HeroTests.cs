namespace Skeleton.Test
{
    using Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGetExperienceAfterKillingTarget()
        {
            //Arange
            var fakeWeapon = new FakeWeapon();
            var systemUnderTest = new Hero("John", fakeWeapon);
            var fakeTarget = new FakeDummy();

            //Act
            systemUnderTest.Attack(fakeTarget);

            //Assert
            Assert.AreEqual(5, systemUnderTest.Experience);

        }

        [Test]
        public void MockingTest()
        {
            //Arange
            var weapon = new Mock<IWeapon>();
            //weapon
            //    .Setup(w => w.Attack(It.IsAny<ITarget>()))
            //    .Callback(() => weapon.Object.DurabilityPoints -= 1);
            //weapon.Setup(w => w.AttackPoints == 10);
            //weapon.Setup(w => w.DurabilityPoints == 3);

            var systemUnderTest = new Hero("John", weapon.Object);
            var target = new Mock<ITarget>();
            target.Setup(t => t.IsDead()).Returns(true);
            target.Setup(t => t.GiveExperience()).Returns(5);

            //Act
            systemUnderTest.Attack(target.Object);

            //Assert
            Assert.AreEqual(5, systemUnderTest.Experience);
        }
    }
}
