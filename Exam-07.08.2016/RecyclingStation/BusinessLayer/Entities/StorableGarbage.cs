namespace RecyclingStation.BusinessLayer.Entities
{
    using System;
    using Attributes;
    using Strategies;

    [StorableGarbage(typeof(StorableGarbageStrategy))]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double volumePerKg, double weight) 
            : base(name, volumePerKg, weight)
        {
        }
    }
}
