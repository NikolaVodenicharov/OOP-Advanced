namespace Hell.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces.Entities.Heroes;
    using Interfaces.Factories;
    using Entities.Inventories;
    using Interfaces.Entities.Items;

    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string heroName, string typeName)
        {
            var type =
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == typeName);
            var heroInventory = this.CreateHeroInventory();
            var parameters = new object[] { heroName, heroInventory };

            var hero =
                Activator
                .CreateInstance(type, parameters)
                as IHero;
            return hero;
        }

        public HeroInventory CreateHeroInventory()
        {
            var heroInventory = new HeroInventory(
                new Dictionary<string, IItem>(),
                new Dictionary<string, IRecipe>());

            return heroInventory;
        }

    }
}
