namespace RecyclingStation.WasteDisposal.Interfaces
{
    using System;

    public static class WasteExtensionMethods
    {
        public static double CalculateWasteVolume (this IWaste waste)
        {
            double wasteVolume = waste.VolumePerKg * waste.Weight;
            return wasteVolume;
        }
    }
}
