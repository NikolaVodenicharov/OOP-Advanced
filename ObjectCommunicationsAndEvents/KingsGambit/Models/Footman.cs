namespace KingsGambit.Models
{
    using Interfaces;
    using System;

    public class Footman : IServant
    {
        public event EventHandler Dead;

        private const int DefaultLife = 2;
        private string name;

        public Footman(string name)
        {
            this.Name = name;
            this.Life = DefaultLife;
        }

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
        public int Life { get; private set; }

        public void DecreaseLife()
        {
            this.Life--;
            this.DeadHandler();
        }

        public void OnKingUnderAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Footman {this.name} is panicking!");
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
