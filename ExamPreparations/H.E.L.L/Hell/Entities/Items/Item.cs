namespace Hell.Entities.Items
{
    using System;
    using System.Text;

    using Interfaces.Entities.Items;

    public class Item : IItem
    {
        public Item (
            string name,
            long agillity,
            long damage,
            long hitPoints,
            long intelligence,
            long strength)
        {
            this.Name = name;
            this.Agility = agillity;
            this.Damage = damage;
            this.HitPoints = hitPoints;
            this.Intelligence = intelligence;
            this.Strength = strength;
        }

        public string Name { get; private set; }
        public long Agility { get; private set; }
        public long Damage { get; private set; }
        public long HitPoints { get; private set; }
        public long Intelligence { get; private set; }
        public long Strength { get; private set; }

        public override string ToString()
        {
            var formattedMessage = new StringBuilder();

            formattedMessage
                .AppendLine($"###Item: {this.Name}")
                .AppendLine($"###+{this.Strength} Strength")
                .AppendLine($"###+{this.Agility} Agility")
                .AppendLine($"###+{this.Intelligence} Intelligence")
                .AppendLine($"###+{this.HitPoints} HitPoints")
                .AppendLine($"###+{this.Damage} Damage");

            return formattedMessage.ToString();
        }
    }
}
