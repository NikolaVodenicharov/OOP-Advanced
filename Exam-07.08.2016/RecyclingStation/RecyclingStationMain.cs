namespace RecyclingStation
{
    using System;
    using System.Collections.Generic;


    using BusinessLayer.Contracts.IO;
    using BusinessLayer.Contracts.Core;

    using BusinessLayer.IO;
    using BusinessLayer.Core;
    using BusinessLayer.Contracts.Factories;
    using BusinessLayer.Factories;

    using WasteDisposal.Interfaces;
    using WasteDisposal;
    using BusinessLayer.Contracts.Data;
    using BusinessLayer.Data;

    public class RecyclingStationMain
    {
        public static void Main()
        {
            RecyclingManager recyclingManager = CreateRecyclingManager();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader, writer, recyclingManager);
            engine.Run();
        }

        private static RecyclingManager CreateRecyclingManager()
        {
            var garbageFactory = new GarbageFactory();

            var strategyHolder = new StrategyHolder(new Dictionary<Type, IGarbageDisposalStrategy>());
            var garbageProcessor = new GarbageProcessor(strategyHolder);

            var requirementData = new StoredData(0, 0);
            var recyclingManagementRequirement = new RecyclingManagementRequirement(requirementData, null);

            var storedData = new StoredData(0, 0);

            var recyclingManager = new RecyclingManager(garbageFactory, garbageProcessor, recyclingManagementRequirement, storedData);

            return recyclingManager;
        }
    }
}
