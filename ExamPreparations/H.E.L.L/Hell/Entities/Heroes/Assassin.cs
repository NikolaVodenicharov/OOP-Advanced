namespace Hell.Entities.Heroes
{
    using System;
    using Interfaces.Entities.Inventories;

    public class Assassin : Hero
    {
        private const int Strength = 25;
        private const int Agility = 100;
        private const int Intelligence = 15;
        private const int HitPoints =  150;
        private const int Damage = 300;

        public Assassin(string name, IInventory inventory) 
            : base(name, Strength, Agility, Intelligence, HitPoints, Damage, inventory)
        {
        }
    }
}
