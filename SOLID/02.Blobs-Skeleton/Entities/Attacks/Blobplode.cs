namespace _02.Blobs.Entities.Attacks
{
    using System;
    using Interfaces;

    public class Blobplode : ISpecialAttack
    {
        private const int DamageMultiplier = 2;
        private const int DamageDivisor = 2;
        private const int HeathDivisor = 2;

        private Blob blob;

        public Blobplode(Blob blob)
        {
            this.blob = blob;
        }

        public void Execute(Blob attacker, Blob target)
        {
            this.IncreaseDamage();
            this.DecreaseHealt();


            target.DecreaseHealth(attacker.CurrentDamage);
        }

        private void IncreaseDamage()
        {
            this.blob.CurrentDamage *= DamageMultiplier;
        }
        private void DecreaseDamage()
        {
            this.blob.CurrentHealth /= DamageDivisor;
        }
        private void DecreaseHealt()
        {
            var initialHealth = (double)this.blob.CurrentHealth;
            var decreasedHealth = (int)Math.Ceiling(initialHealth / 2);
            this.blob.CurrentHealth = decreasedHealth;
        }
    }
}
