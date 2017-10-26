namespace Hell.Interfaces.Factories
{
    using System;

    using Entities.Items;

    public interface IRecipeFactory
    {
        IRecipe CreateItem(
            string itemType,
            string name,
            long agility,
            long damage,
            long hitPoints,
            long intelligence,
            long strength,
            string[] requiredItems);
    }
}
