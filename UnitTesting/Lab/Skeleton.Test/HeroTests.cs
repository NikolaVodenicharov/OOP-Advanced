namespace Skeleton.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGetExperienceAfterKillingTarget()
        {
            //Arange
            var testingUnit = new Hero("John", new Axe(10, 3));
            var target = new Dummy(10, 5);

            //Act
            testingUnit.Attack(target);

            //Assert
            Assert.AreEqual(5, testingUnit.Experience);

        }
    }
}
