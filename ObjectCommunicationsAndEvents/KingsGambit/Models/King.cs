namespace KingsGambit.Models
{
    using Interfaces;
    using System;

    public class King : IPerson
    {
        public event EventHandler KingUnderAttack;

        private string name;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public void KingIsAttacked()
        {
            Console.WriteLine($"King {this.name} is under attack!");

            if (this.KingUnderAttack != null)
            {
                this.KingUnderAttack(this, null);
            }
        }
    }
}
