﻿namespace Hell.Interfaces.Entities.Heroes
{
    using System;

    using Inventories;

    public interface IHero : IComparable<IHero>
    {
        string Name { get; }
        long Strength { get; }
        long Agility { get; }
        long Intelligence { get; }
        long HitPoints { get; }
        long Damage { get; }
        IInventory Inventory { get; }
    }
}
