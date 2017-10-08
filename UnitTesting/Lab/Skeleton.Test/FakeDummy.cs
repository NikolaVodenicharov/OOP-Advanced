using System;
using Skeleton.Interfaces;

namespace Skeleton.Test
{
    public class FakeDummy : ITarget
    {
        public int Healt
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

        public int KeptExperience
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

        public int GiveExperience() => 5;

        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
