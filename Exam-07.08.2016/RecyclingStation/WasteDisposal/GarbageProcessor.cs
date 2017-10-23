namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;
    using BusinessLayer.Strategies;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            var garbageAttribute = GetGarbageAttribute(garbage);

            CreateStrategyIfNotExist(garbageAttribute);
            var strategy = GetStrategy(garbageAttribute);

            var processingData = strategy.ProcessGarbage(garbage);

            return processingData;
        }

        private IGarbageDisposalStrategy GetStrategy(DisposableAttribute garbageAttribute)
        {
            var attributeType = garbageAttribute.GetType();
            var strategy = this.StrategyHolder.GetDisposalStrategies[attributeType];

            return strategy;
        }
        private DisposableAttribute GetGarbageAttribute(IWaste garbage)
        {
            var garbageType = garbage.GetType();

            var garbageAttribute =
                garbageType
                .GetCustomAttributes(typeof(DisposableAttribute), true)
                .FirstOrDefault()
                as DisposableAttribute;

            CheckAttributeNullException(garbageAttribute);

            return garbageAttribute;
        }
        private void CheckAttributeNullException(Attribute attribute)
        {
            if (attribute == null)
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }
        }
        private void CreateStrategyIfNotExist(DisposableAttribute garbageAttribute)
        {
            var attributeType = garbageAttribute.GetType();
            var doesContainStrategy = this.StrategyHolder.GetDisposalStrategies.ContainsKey(attributeType);

            if (!doesContainStrategy)
            {
                var strategyType = garbageAttribute.CorrespondingStrategyType;
                var activatedStrategy =
                    Activator.CreateInstance(strategyType)
                    as IGarbageDisposalStrategy;

                this.StrategyHolder.AddStrategy(attributeType, activatedStrategy);
            }
        }
    }
}
