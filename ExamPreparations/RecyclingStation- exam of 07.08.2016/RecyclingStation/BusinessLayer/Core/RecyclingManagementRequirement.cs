namespace RecyclingStation.BusinessLayer.Core
{
    using System;

    using Contracts.Core;
    using Contracts.Data;
    using WasteDisposal.Interfaces;

    public class RecyclingManagementRequirement : IRecyclingManagementRequirement
    {
        IStoredData dataRequirements;
        private Type targetGarbageType;

        public RecyclingManagementRequirement(IStoredData dataRequirements, Type targetGarbageType)
        {
            this.DataRequirements = dataRequirements;
            this.TargetGarbageType = targetGarbageType;
        }

        public IStoredData DataRequirements
        {
            get
            {
                return this.dataRequirements;
            }
            private set
            {
                this.dataRequirements = value;
            }
        }
        public Type TargetGarbageType
        {
            get
            {
                return this.targetGarbageType;
            }
            private set
            {
                this.targetGarbageType = value;
            }
        }

        public void ChangeManagementRequirement(IStoredData dataRequirements, Type targetGarbageType)
        {
            this.DataRequirements = dataRequirements;
            this.TargetGarbageType = targetGarbageType;
        }
        public bool AreRequirementsSatisfy(IStoredData storedData, IWaste garbage)
        {
            if (garbage.GetType() == this.targetGarbageType)
            {
                var isCapitalEnought = this.dataRequirements.CapitalBalance <= storedData.CapitalBalance;
                var isEnergyEnought = this.dataRequirements.EnergyBalance <= storedData.EnergyBalance;

                if (!isCapitalEnought || !isEnergyEnought)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
