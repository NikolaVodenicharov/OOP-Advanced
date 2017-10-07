namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;
    using Attributes;

    public class Add : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public Add(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];
            var unit = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unit);
            var output = unitType + " added!";
            return output;
        }
    }
}