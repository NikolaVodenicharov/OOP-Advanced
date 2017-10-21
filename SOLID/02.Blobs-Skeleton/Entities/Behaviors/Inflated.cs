namespace _02.Blobs.Entities.Behaviors
{
    using Interfaces;
    using System;

    public class Inflated : IBehavior
    {
        private const int BasicHealth = 50;
        private const int SubstractionHealth = 10;

        public Inflated()
        {
            this.IsTriggered = false;
        }

        public int HealthModificator { get; private set; }
        public int DamageModificator { get; private set; }
        public bool IsTriggered { get; private set; }

        public void Trigger(Blob blob)
        {
            this.HealthModificator = BasicHealth;
            this.DamageModificator = 0;
            this.IsTriggered = true;
        }

        public void ProcessNextTurn()
        {
            if (this.IsTriggered)
            {
                this.SubstractHealt();
            }
        }

        private void SubstractHealt()
        {
            this.HealthModificator = -SubstractionHealth;
        }
    }
}
