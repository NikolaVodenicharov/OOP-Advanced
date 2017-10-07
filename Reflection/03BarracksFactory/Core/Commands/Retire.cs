namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;
    using Attributes;

    public class Retire : Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];
            this.repository.RemoveUnit(unitType);
            var output = unitType + " retired!";
            return output;
        }
    }
}
