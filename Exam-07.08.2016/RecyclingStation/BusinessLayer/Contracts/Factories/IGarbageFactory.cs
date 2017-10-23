namespace RecyclingStation.BusinessLayer.Contracts.Factories
{
    using System;
    using WasteDisposal.Interfaces;

    public interface IGarbageFactory
    {

        IWaste CreateGarbage(string name, double weight, double volumePerKg, string type);
    }
}
