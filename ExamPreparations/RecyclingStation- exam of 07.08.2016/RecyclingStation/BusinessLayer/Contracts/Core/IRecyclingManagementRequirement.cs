namespace RecyclingStation.BusinessLayer.Contracts.Core
{
    using System;

    using RecyclingStation.WasteDisposal.Interfaces;
    using Data;

    public interface IRecyclingManagementRequirement
    {
        IStoredData DataRequirements { get; }
        Type TargetGarbageType { get; }

        void ChangeManagementRequirement(IStoredData dataRequirements, Type targetGarbageType);
        bool AreRequirementsSatisfy(IStoredData processingData, IWaste garbage);
    }
}
