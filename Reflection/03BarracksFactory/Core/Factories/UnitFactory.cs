namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string UnitNameSpace = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            var type = Type.GetType(UnitNameSpace + unitType);
            var unit = (IUnit)Activator.CreateInstance(type);
            return unit;
        }
    }
}
