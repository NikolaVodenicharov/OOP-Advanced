namespace Hell.Entities.Items
{
    using System;
    using System.Collections.Generic;
    using Interfaces.Entities.Items;

    public class Recipe : IRecipe
    {
        public Recipe(
            string name,
            long agillity,
            long damage,
            long hitPoints,
            long intelligence,
            long strength,
            string[] requestedItems)
        {
            this.Name = name;
            this.Agility = agillity;
            this.Damage = damage;
            this.HitPoints = hitPoints;
            this.Intelligence = intelligence;
            this.Strength = strength;
            this.RequestedItems = requestedItems;
        }

        public string Name { get; private set; }
        public long Agility { get; private set; }
        public long Damage { get; private set; }
        public long HitPoints { get; private set; }
        public long Intelligence { get; private set; }
        public long Strength { get; private set; }
        public string[] RequestedItems { get; private set; }
    }
}
