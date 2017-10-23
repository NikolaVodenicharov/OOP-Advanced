namespace RecyclingStation.BusinessLayer.Strategies
{
    using System;
    using WasteDisposal.Interfaces;

    public class StorableGarbageStrategy : GarbageStrategy
    {
        private const double CapitalUsedCoefficient = 0.65;
        private const double EnergyUsedCoefficient = 0.13;

        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            var volume = WasteExtensionMethods.CalculateWasteVolume(garbage);
            var capitalProduced = 0;
            var capitalUsed = volume * CapitalUsedCoefficient;

            var capitalBalance = capitalProduced - capitalUsed;
            return capitalBalance;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            var volume = WasteExtensionMethods.CalculateWasteVolume(garbage);
            var energyProduced = 0;
            var energyUsed = volume * EnergyUsedCoefficient;

            var energyBalance = energyProduced - energyUsed;
            return energyBalance;
        }
    }
}
