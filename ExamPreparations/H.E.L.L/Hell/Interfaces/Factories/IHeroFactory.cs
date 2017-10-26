namespace Hell.Interfaces.Factories
{
    using System;
    using Entities.Heroes;

    public interface IHeroFactory
    {
        IHero CreateHero(string heroName, string typeName);
    }
}
