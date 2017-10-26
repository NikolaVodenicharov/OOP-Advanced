namespace Hell.Core.Commands
{
    using System;

    using Attributes;
    using Interfaces.Factories;
    using Interfaces.Repositories;

    public class ItemCommand : Command
    {
        private const string ItemCreateMessage = "Added item - {0} to Hero - {1}";
        private const string ItemType = "Item";

        [CommandInjection]
        private IHeroRepository heroRepository;
        [CommandInjection]
        IItemFactory itemFactory;

        private string heroName;

        private string itemName;
        private long agility;
        private long damage;
        private long hitPoints;
        private long intelligence;
        private long strength;

        public ItemCommand(params string[] parameters)
        {
            this.itemName = parameters[0];
            this.heroName = parameters[1];
            this.strength = long.Parse(parameters[2]);
            this.agility = long.Parse(parameters[3]);
            this.intelligence = long.Parse(parameters[4]);
            this.hitPoints = long.Parse(parameters[5]);
            this.damage = long.Parse(parameters[6]);
        }

        public override string Execute()
        {
            var item = 
                this
                .itemFactory
                .CreateItem(
                    ItemType,
                    this.itemName,
                    this.agility,
                    this.damage,
                    this.hitPoints,
                    this.intelligence,
                    this.strength);
            this
                .heroRepository
                .Heroes[heroName]
                .Inventory
                .AddItem(item);

            var message = string.Format(ItemCreateMessage, this.itemName, this.heroName);
            return message;
        }
    }
}
