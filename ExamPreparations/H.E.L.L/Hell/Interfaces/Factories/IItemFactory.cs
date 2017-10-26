namespace Hell.Interfaces.Factories
{
    using System;
    using Entities.Items;

    public interface IItemFactory
    {
        IItem CreateItem(
            string itemType,
            string name,
            long agility,
            long damage,
            long hitPoints,
            long intelligence,
            long strength);
    }
}
