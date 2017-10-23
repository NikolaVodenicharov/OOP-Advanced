namespace RecyclingStation.BusinessLayer.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;

    using Contracts.Factories;
    using WasteDisposal.Interfaces;

    public class GarbageFactory : IGarbageFactory
    {
        private const string GarbageTypeSuffix = "Garbage";

        public IWaste CreateGarbage(string name, double weight, double volumePerKg, string type)
        {
            var garbageTypeFullName = type + GarbageTypeSuffix;
            var garbageType = 
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == garbageTypeFullName);

            var parameters = new object[] { name, weight, volumePerKg };

            var garbage = (IWaste)Activator.CreateInstance(garbageType, parameters);

            return garbage;
        }

    }
}
