namespace RecyclingStation.BusinessLayer.Strategies
{
    using Data;
    using System;
    using WasteDisposal.Interfaces;

    public abstract class GarbageStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            double capital = this.CalculateCapitalBalance(garbage);
            double energy = this.CalculateEnergyBalance(garbage);

            var processingData = new ProcessingData(capital, energy);

            return processingData;
        }

        protected abstract double CalculateCapitalBalance(IWaste garbage);
        protected abstract double CalculateEnergyBalance(IWaste garbage);
    }
}
