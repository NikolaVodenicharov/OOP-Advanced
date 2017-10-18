namespace KingsGambit.Models
{
    using Interfaces;
    using System;

    public class Footman : IServant
    {
        private string name;

        public Footman(string name)
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

        public void SubscribeKingUnderAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Footman {this.name} is panicking!");
        }
    }
}
