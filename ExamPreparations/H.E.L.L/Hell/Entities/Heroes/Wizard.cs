namespace Hell.Entities.Heroes
{
    using System;
    using Interfaces.Entities.Inventories;

    public class Wizard : Hero
    {
        private const int Strength = 25;
        private const int Agility = 25;
        private const int Intelligence = 100;
        private const int HitPoints = 100;
        private const int Damage = 250;

        public Wizard(string name, IInventory inventory) 
            : base(name, Strength, Agility, Intelligence, HitPoints, Damage, inventory)
        {
        }
    }
}
