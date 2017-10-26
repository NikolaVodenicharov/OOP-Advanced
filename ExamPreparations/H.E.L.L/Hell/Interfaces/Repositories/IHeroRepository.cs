namespace Hell.Interfaces.Repositories
{
    using System;

    using Entities.Heroes;
    using System.Collections.Generic;

    public interface IHeroRepository
    {
        IDictionary<string, IHero> Heroes { get;}
        void AddHero(IHero hero);
    }
}
