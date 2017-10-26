namespace RecyclingStation.BusinessLayer.Strategies
{
    using System;
    using WasteDisposal.Interfaces;


    public class BurnableGarbageStrategy : GarbageStrategy
    {
        private const double EnergyProducedCoefficient = 1;
        private const double EnergyUsedCoefficient = 0.2;

        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            var capitalBalance = 0;
            return capitalBalance;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            var volume = WasteExtensionMethods.CalculateWasteVolume(garbage);
            var energyProduced = volume * EnergyProducedCoefficient;
            var energyUsed = volume * EnergyUsedCoefficient;

            var energyBalance = energyProduced - energyUsed;
            return energyBalance;
        }
    }
}
