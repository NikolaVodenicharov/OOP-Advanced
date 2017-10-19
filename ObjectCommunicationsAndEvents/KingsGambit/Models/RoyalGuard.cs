namespace KingsGambit.Models
{
    using KingsGambit.Interfaces;
    using System;

    public class RoyalGuard : IServant
    {
        public event EventHandler Dead;

        private const int DefaultLife = 3;
        private string name;

        public RoyalGuard(string name)
        {
            this.Name = name;
            this.Life = DefaultLife;
        }

        public int Life { get; private set; }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public void DecreaseLife()
        {
            this.Life--;
            this.DeadHandler();
        }
        public void OnKingUnderAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Royal Guard {this.name} is defending!");
        }

        private void DeadHandler()
        {
            var isDead = this.IsDead();
            if (isDead)
            {
                this.TriggerDeadEvent();
            }
        }
        private bool IsDead()
        {
            if (this.Life == 0)
            {
                return true;
            }

            return false;
        }
        private void TriggerDeadEvent()
        {
            if (this.Dead != null)
            {
                this.Dead(this, null);
            }
        }
    }
}
