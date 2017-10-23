namespace RecyclingStation.BusinessLayer.Entities
{
    using System;
    using Attributes;
    using Strategies;

    [BurnableGarbage(typeof(BurnableGarbageStrategy))]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double volumePerKg, double weight) 
            : base(name, volumePerKg, weight)
        {
        }
    }
}
