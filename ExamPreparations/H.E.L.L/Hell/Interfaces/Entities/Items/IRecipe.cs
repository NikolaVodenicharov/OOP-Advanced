namespace Hell.Interfaces.Entities.Items
{
    using System;
    using System.Collections.Generic;

    using Items;

    public interface IRecipe
    {
        string Name { get; }
        long Strength { get; }
        long Agility { get; }
        long Intelligence { get; }
        long HitPoints { get; }
        long Damage { get; }

        string[] RequestedItems { get; }
    }
}
