namespace Hell.Entities.Heroes
{
    using System;
    using Interfaces.Entities.Inventories;

    public class Barbarian : Hero
    {
        private const int Strength = 90;
        private const int Agility = 25;
        private const int Intelligence = 10;
        private const int HitPoints = 350;
        private const int Damage = 150;

        public Barbarian(string name, IInventory inventory) 
            : base(name, Strength, Agility, Intelligence, HitPoints, Damage, inventory)
        {
        }
    }
}
