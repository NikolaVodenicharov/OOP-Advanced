namespace RecyclingStation.BusinessLayer.Data
{
    using System;
    using WasteDisposal.Interfaces;

    public class ProcessingData : IProcessingData
    {
        public ProcessingData (double capital, double energy)
        {
            this.CapitalBalance = capital;
            this.EnergyBalance = energy;
        }
        public double CapitalBalance { get; private set; }

        public double EnergyBalance { get; private set; }
    }
}
