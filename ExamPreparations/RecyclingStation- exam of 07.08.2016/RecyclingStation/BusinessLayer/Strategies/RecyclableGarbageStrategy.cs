namespace RecyclingStation.BusinessLayer.Strategies
{
    using System;
    using WasteDisposal.Interfaces;

    public class RecyclableGarbageStrategy : GarbageStrategy
    {
        private const int MoneyPerKilogram = 400;
        private const double EnergyUsedCoefficient = 0.5;

        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            var capitalEarned = garbage.Weight * MoneyPerKilogram;
            var capitalUsed = 0;

            var capitalBalance = capitalEarned - capitalUsed;
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