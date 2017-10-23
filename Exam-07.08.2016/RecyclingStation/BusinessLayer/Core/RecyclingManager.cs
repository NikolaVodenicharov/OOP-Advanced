namespace RecyclingStation.BusinessLayer.Core
{
    using System;

    using Contracts.Core;
    using Contracts.Factories;
    using WasteDisposal.Interfaces;

    public class RecyclingManager : IRecyclingManager
    {
        private const string DecimalPrecision = "f2";
        private const string ProcessFormat = "{0} kg of {1} successfully processed!";
        private const string StatusFormat = "Energy: {0} Capital: {1}";

        private IGarbageFactory garbageFactory;
        private IGarbageProcessor garbageProcessor;

        private double capital;
        private double energy;

        public RecyclingManager(
            IGarbageFactory garbageFactory, 
            IGarbageProcessor garbageProcessor, 
            double capital, 
            double energy)
        {
            this.garbageFactory = garbageFactory;
            this.garbageProcessor = garbageProcessor;
            this.capital = capital;
            this.energy = energy;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            var garbage = this.garbageFactory.CreateGarbage(name, weight, volumePerKg, type);

            var processingData = this.garbageProcessor.ProcessWaste(garbage);
            this.capital += processingData.CapitalBalance;
            this.energy += processingData.EnergyBalance;

            var message =
                String.Format(
                ProcessFormat,
                garbage.Weight.ToString(DecimalPrecision),
                garbage.Name);

            return message;
        }

        public string Status()
        {
            var message =
                String.Format(
                StatusFormat,
                this.energy.ToString(DecimalPrecision),
                this.capital.ToString(DecimalPrecision));

            return message;
        }
    }
}
