namespace KingsGambit.Models
{
    using KingsGambit.Interfaces;
    using System;

    public class RoyalGuard : IServant
    {
        private string name;

        public RoyalGuard(string name)
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
            Console.WriteLine($"Royal Guard {this.name} is defending!");
        }
    }
}
