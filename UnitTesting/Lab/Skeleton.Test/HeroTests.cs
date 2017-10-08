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

        //[Test]
        //public void MockingTest()
        //{
        //    //Arange
        //    var weapon = new Mock<IWeapon>();
        //    weapon
        //        .Setup(w => w.Attack(It.IsAny<ITarget>()))
        //        .Callback(() => weapon.Object.DurabilityPoints -= 1);
        //    //weapon.Setup(w => w.AttackPoints == 10);
        //    //weapon.Setup(w => w.DurabilityPoints == 3);

        //    var systemUnderTest = new Hero("John", weapon.Object);
        //    var target = new Dummy(10, 5);

        //    //Act
        //    systemUnderTest.Attack(target);

        //    //Assert
        //    Assert.AreEqual(5, systemUnderTest.Experience);
        //}
    }
}
