namespace Hell.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;

    using Interfaces.Entities.Items;
    using Interfaces.Factories;

    public class RecipeFactory : IRecipeFactory
    {
        public IRecipe CreateItem(
            string recipeType, 
            string name, 
            long agility, 
            long damage, 
            long hitPoints, 
            long intelligence, 
            long strength, 
            string[] requiredItems)
        {
            var type =
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == recipeType);
            var parameters = new object[] {
                name,
                agility,
                damage,
                hitPoints,
                intelligence,
                strength,
                requiredItems.ToArray()};
            var recipe =
                Activator
                .CreateInstance(type, parameters)
                as IRecipe;

            return recipe;
        }
    }
}
