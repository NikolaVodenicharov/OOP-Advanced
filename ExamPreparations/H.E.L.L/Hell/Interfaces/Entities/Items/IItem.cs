namespace Hell.Interfaces.Entities.Items
{
    using System;

    public interface IItem
    {
        string Name { get; }
        long Strength { get; }
        long Agility { get; }
        long Intelligence { get; }
        long HitPoints { get; }
        long Damage { get; }
    }
}
