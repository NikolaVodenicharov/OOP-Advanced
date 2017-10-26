namespace RecyclingStation.BusinessLayer.Data
{
    using System;
    using Contracts.Data;
    using WasteDisposal.Interfaces;

    public class StoredData : IStoredData
    {
        public StoredData(double capital, double energy)
        {
            this.CapitalBalance = capital;
            this.EnergyBalance = energy;
        }
        public double CapitalBalance { get; private set; }

        public double EnergyBalance { get; private set; }

        public void AddData(IProcessingData processingData)
        {
            this.CapitalBalance += processingData.CapitalBalance;
            this.EnergyBalance += processingData.EnergyBalance;
        }
    }
}
