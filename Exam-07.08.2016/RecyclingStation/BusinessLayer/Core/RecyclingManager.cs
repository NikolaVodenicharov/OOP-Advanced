namespace RecyclingStation.BusinessLayer.Core
{
    using System;

    using Contracts.Core;
    using Contracts.Factories;
    using WasteDisposal.Interfaces;
    using Contracts.Data;
    using Data;
    using System.Reflection;
    using System.Linq;

    public class RecyclingManager : IRecyclingManager
    {
        private const string DecimalPrecision = "f2";
        private const string ProcessFormat = "{0} kg of {1} successfully processed!";
        private const string StatusFormat = "Energy: {0} Capital: {1}";
        private const string ChangeManagementRequirementMessage = "Management requirement changed!";
        private const string DeniedProcessMessage = "Processing Denied!";

        private IGarbageFactory garbageFactory;
        private IGarbageProcessor garbageProcessor;
        IRecyclingManagementRequirement recyclingManagementRequirement;
        private IStoredData storedData;


        public RecyclingManager(
            IGarbageFactory garbageFactory, 
            IGarbageProcessor garbageProcessor,
            IRecyclingManagementRequirement recyclingManagementRequirement,
            IStoredData storedData)
        {
            this.garbageFactory = garbageFactory;
            this.garbageProcessor = garbageProcessor;
            this.recyclingManagementRequirement = recyclingManagementRequirement;
            this.storedData = storedData;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            var garbage = this.garbageFactory.CreateGarbage(name, weight, volumePerKg, type);
            var areRequirementsSatisfy = this.recyclingManagementRequirement.AreRequirementsSatisfy(this.storedData, garbage);

            if (areRequirementsSatisfy)
            {
                var processingData = this.garbageProcessor.ProcessWaste(garbage);
                this.storedData.AddData(processingData);

                var processedGarbageMessage =
                    String.Format(
                    ProcessFormat,
                    garbage.Weight.ToString(DecimalPrecision),
                    garbage.Name);
                return processedGarbageMessage;
            }

            return DeniedProcessMessage;
        }
        public string Status()
        {
            var message =
                String.Format(
                StatusFormat,
                this.storedData.EnergyBalance.ToString(DecimalPrecision),
                this.storedData.CapitalBalance.ToString(DecimalPrecision));

            return message;
        }
        public string ChangeManagementRequirement(double energyBalance, double capitalBalance, string type)
        {
            var dataRequirement = new StoredData(capitalBalance, energyBalance);
            Type garbageType = GetGarbageType(type);

            this.recyclingManagementRequirement.ChangeManagementRequirement(dataRequirement, garbageType);

            return ChangeManagementRequirementMessage;
        }

        private Type GetGarbageType(string type)
        {
            var garbageTypeSuffix = "Garbage";
            var garbageTypeFullName = type + garbageTypeSuffix;
            var garbageType =
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == garbageTypeFullName);

            return garbageType;
        }
    }
}
