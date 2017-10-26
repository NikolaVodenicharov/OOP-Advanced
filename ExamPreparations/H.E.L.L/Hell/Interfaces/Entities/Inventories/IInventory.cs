namespace Hell.Interfaces.Entities.Inventories
{
    using System;
    using System.Collections.Generic;

    using Items;

    public interface IInventory
    {
        IDictionary<string, IItem> Items { get; }
        IDictionary<string, IRecipe> Recipes { get; }

        long GetStrength();
        long GetAgility();
        long GetIntelligence();
        long GetHitPoints();
        long GetDamage();

        void AddItem(IItem commonItem);
        void AddRecipe(IRecipe recipeItem);

        void RemoveItem(string itemName);

        void CheckRecipes();
        void CombineRecipe(IRecipe recipeItem);
    }
}
