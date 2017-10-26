namespace Hell.Entities.Inventories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Hell.Interfaces.Entities.Inventories;
    using Hell.Interfaces.Entities.Items;
    using Hell.Entities.Items;

    public class HeroInventory : IInventory
    {
        private IDictionary<string, IItem> items;
        private IDictionary<string, IRecipe> recipes;

        public HeroInventory(
            IDictionary<string, IItem> items, 
            IDictionary<string, IRecipe> recipes)
        {
            this.Items = items;
            this.recipes = recipes;
        }

        //readonly ?
        public IDictionary<string, IItem> Items
        {
            get
            {
                return this.items;
            }
            private set
            {
                this.items = value;
            }
        }
        public IDictionary<string, IRecipe> Recipes
        {
            get
            {
                return this.recipes;
            }
            private set
            {
                this.recipes = value;
            }
        }

        public void AddItem(IItem commonItem)
        {
            this.items.Add(commonItem.Name, commonItem);
            this.CheckRecipes();
        }
        public void AddRecipe(IRecipe recipeItem)
        {
            this.recipes.Add(recipeItem.Name, recipeItem);
            this.CheckRecipes();
        }

        public void CheckRecipes()
        {
            foreach (var recipe in this.recipes.Values)
            {
                var requiredItems = recipe.RequestedItems.ToList();

                foreach (var itemName in this.items.Keys)
                {
                    if (requiredItems.Contains(itemName))
                    {
                        requiredItems.Remove(itemName);
                    }
                }

                if (requiredItems.Count == 0)
                {
                    this.CombineRecipe(recipe);
                }
            }
        }
        public void CombineRecipe(IRecipe recipeItem)
        {
            for (int i = 0; i < recipeItem.RequestedItems.Length; i++)
            {
                var itemName = recipeItem.RequestedItems[i];
                this.RemoveItem(itemName);
            }

            var newItem = new Item(
                recipeItem.Name,
                recipeItem.Agility,
                recipeItem.Damage,
                recipeItem.HitPoints,
                recipeItem.Intelligence,
                recipeItem.Strength);

            this.items.Add(newItem.Name, newItem);
        }

        public long GetStrength()
        {
            var sum = this.items.Values.Sum(i => (long)i.Strength);
            return sum;
        }
        public long GetAgility()
        {
            var sum = this.items.Values.Sum(i => (long)i.Agility);
            return sum;
        }
        public long GetIntelligence()
        {
            var sum = this.items.Values.Sum(i => (long)i.Intelligence);
            return sum;
        }
        public long GetHitPoints()
        {
            var sum = this.items.Values.Sum(i => (long)i.HitPoints);
            return sum;
        }
        public long GetDamage()
        {
            var sum = this.items.Values.Sum(i => (long)i.Damage);
            return sum;
        }

        public void RemoveItem(string itemName)
        {
            this.items.Remove(itemName);
        }
    }
}