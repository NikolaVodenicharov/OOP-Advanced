namespace RecyclingStation.BusinessLayer.Entities
{
    using System;
    using Attributes;
    using Strategies;

    [RecyclableGarbage(typeof(RecyclableGarbageStrategy))]
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double volumePerKg, double weight) 
            : base(name, volumePerKg, weight)
        {
        }
    }
}
