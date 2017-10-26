namespace RecyclingStation.BusinessLayer.Contracts.Data
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public interface IStoredData
    {
        double CapitalBalance { get; }

        double EnergyBalance { get; }

        void AddData(IProcessingData processingData);
    }
}
