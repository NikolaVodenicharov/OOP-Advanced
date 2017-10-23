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

    public class RecyclingStationMain
    {
        public static void Main()
        {
            IStrategyHolder strategyHolder = new StrategyHolder(new Dictionary<Type, IGarbageDisposalStrategy>());
            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);

            IGarbageFactory garbageFactory = new GarbageFactory();

            IRecyclingManager recyclingManager = new RecyclingManager(garbageFactory, garbageProcessor, 0, 0);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            var engine = new Engine(reader, writer, recyclingManager);
            engine.Run();
        }
    }
}
