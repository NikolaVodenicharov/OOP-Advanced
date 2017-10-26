namespace Hell.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;

    using Interfaces.Entities.Items;
    using Interfaces.Factories;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(
            string itemType,
            string name,
            long agility,
            long damage,
            long hitPoints,
            long intelligence,
            long strength)

        {
            var type =
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == itemType);
            var parameters = new object[] {
                name,
                agility,
                damage,
                hitPoints,
                intelligence,
                strength };
            var item =
                Activator
                .CreateInstance(type, parameters)
                as IItem;
            return item;
        }
    }
}
