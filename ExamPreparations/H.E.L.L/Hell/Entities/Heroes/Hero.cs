namespace Hell.Entities.Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Hell.Interfaces.Entities.Heroes;
    using Hell.Interfaces.Entities.Inventories;
    using Interfaces.Entities.Items;

    public abstract class Hero : IHero
    {
        private string name;
        private long strength;
        private long agility;
        private long intelligence;
        private long hitPoints;
        private long damage;
        private IInventory inventory;

        protected Hero(
            string name,
            int strength,
            int agility,
            int intelligence,
            int hitPoints,
            int damage,
            IInventory inventory)
        {
            this.Name = name;
            this.strength = strength;
            this.agility = agility;
            this.intelligence = intelligence;
            this.hitPoints = hitPoints;
            this.damage = damage;
            this.Inventory = inventory;
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
        public long Strength
        {
            get { return this.strength + this.inventory.GetStrength(); }
            private set { this.strength = value; }
        }
        public long Agility
        {
            get { return this.agility + this.inventory.GetAgility(); }
            private set { this.agility = value; }
        }
        public long Intelligence
        {
            get { return this.intelligence + this.inventory.GetIntelligence(); }
            private set { this.intelligence = value; }
        }
        public long HitPoints
        {
            get { return this.hitPoints + this.inventory.GetHitPoints(); }
            set { this.hitPoints = value; }
        }
        public long Damage
        {
            get { return this.damage + this.inventory.GetDamage(); }
            private set { this.damage = value; }
        }
        public IInventory Inventory
        {
            get
            {
                return this.inventory;
            }
            private set
            {
                this.inventory = value;
            }
        }

        private long PrimaryStats (IHero hero)
        {
            return hero.Strength + hero.Agility + hero.Intelligence; 
        }
        private long SecondaryStats (IHero hero)
        {
            return hero.HitPoints + hero.Damage;
        }
        public int CompareTo(IHero other)
        {
            var result = 0;

            if (ReferenceEquals(this, other))
            {
                result = 0;
            }
            else if (ReferenceEquals(null, other))
            {
                result = 1;
            }
            else
            {
                result = 
                    this.PrimaryStats(this)
                    .CompareTo(
                        this.PrimaryStats(other));

                if (result == 0)
                {
                    result = 
                        this.SecondaryStats(this)
                        .CompareTo(
                            this.SecondaryStats(other));
                }
            }

            return result;
        }

        public override string ToString()
        {
            var formattedMessage = new StringBuilder();

            formattedMessage
                .AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}")
                .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
                .AppendLine($"Strength: {this.Strength}")
                .AppendLine($"Agility: {this.Agility}")
                .AppendLine($"Intelligence: {this.Intelligence}");

            if (this.inventory.Items.Count == 0)
            {
                formattedMessage.AppendLine("Items: None");
            }
            else
            {
                formattedMessage.AppendLine("Items:");
                foreach (var item in this.inventory.Items.Values)
                {
                    formattedMessage.AppendLine(item.ToString());
                }
            }

            return formattedMessage.ToString().TrimEnd();
        }
    }
}