namespace Skeleton.Test
{
    using System;
    using Skeleton.Interfaces;

    public class FakeWeapon : IWeapon
    {
        public int AttackPoints
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int DurabilityPoints
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Attack(ITarget target)
        {

        }
    }
}
