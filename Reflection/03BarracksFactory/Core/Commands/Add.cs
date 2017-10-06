namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;

    public class Add : Command
    {
        public Add(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];
            var unit = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unit);
            var output = unitType + " added!";
            return output;
        }
    }
}