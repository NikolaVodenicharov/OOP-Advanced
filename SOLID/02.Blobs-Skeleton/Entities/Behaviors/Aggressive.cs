namespace _02.Blobs.Entities.Behaviors
{
    using System;
    using _02.Blobs.Interfaces;

    public class Aggressive : IBehavior
    {
        private const int DamageMultiplier = 1;
        private const int DamageSubstractor = 5;

        private int AdditionalAddedHealt;
        private bool isProcessingTurns;
        private bool isFirstTurn;

        public Aggressive()
        {
            this.IsTriggered = false;
            this.isFirstTurn = true;
        }

        public int HealthModificator { get; private set; }
        public int DamageModificator { get; private set; }
        public bool IsTriggered { get; private set; }

        public void Trigger(Blob blob)
        {
            if (!this.IsTriggered)
            {
                this.HealthModificator = 0;
                this.DamageModificator = blob.CurrentDamage * DamageMultiplier;
                this.AdditionalAddedHealt = DamageModificator;
                this.IsTriggered = true;
            }
        }

        public void ProcessNextTurn()
        {
            if (this.IsTriggered)
            {
                this.DecreaseDamage();
            }
        }

        private void DecreaseDamage()
        {
            if (this.isFirstTurn)
            {
                this.isFirstTurn = false;
            }
            else if((this.AdditionalAddedHealt - DamageSubstractor) >= 0)
            {
                this.DamageModificator = -DamageSubstractor;
                this.AdditionalAddedHealt -= DamageSubstractor;
            }
            else
            {
                this.DamageModificator = this.AdditionalAddedHealt;
            }
        }
    }
}