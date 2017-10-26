namespace Hell.Core.Commands
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Attributes;
    using Interfaces.Repositories;
    using Interfaces.Factories;

    public class RecipeCommand : Command
    {
        private const string RecipeCreatedMessage = "Added recipe - {0} to Hero - {1}";
        private const string RecipeType = "Recipe";

        [CommandInjection]
        private IHeroRepository heroRepository;
        [CommandInjection]
        private IRecipeFactory recipeFactory;

        private string heroName;

        private string recipeName;
        private long strength;
        private long agility;
        private long intelligence;
        private long hitPoints;
        private long damage;
        private string[] requestedItems;

        public RecipeCommand(params string[] parameters)
        {
            this.recipeName = parameters[0];
            this.heroName = parameters[1];
            this.strength = long.Parse(parameters[2]);
            this.agility = long.Parse(parameters[3]);
            this.intelligence = long.Parse(parameters[4]);
            this.hitPoints = long.Parse(parameters[5]);
            this.damage = long.Parse(parameters[6]);
            this.requestedItems = parameters.Skip(7).Take(parameters.Length - 7).ToArray();
        }

        public override string Execute()
        {
            var recipe =
                this
                .recipeFactory
                .CreateItem(
                    RecipeType,
                    this.recipeName,
                    this.agility,
                    this.damage,
                    this.hitPoints,
                    this.intelligence,
                    this.strength,
                    this.requestedItems);
            this
                .heroRepository
                .Heroes[heroName]
                .Inventory
                .AddRecipe(recipe);

            var message = string.Format(RecipeCreatedMessage, this.recipeName, this.heroName);
            return message;
        }
    }
}
