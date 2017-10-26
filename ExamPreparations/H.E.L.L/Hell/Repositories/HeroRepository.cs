namespace Hell.Repositories
{
    using System;
    using System.Collections.Generic;

    using Interfaces.Entities.Heroes;
    using Interfaces.Repositories;

    public class HeroRepository : IHeroRepository
    {
        private IDictionary<string, IHero> heroes;

        public HeroRepository(IDictionary<string, IHero> heroes)
        {
            this.Heroes = heroes;
        }

        public IDictionary<string, IHero> Heroes
        {
            get
            {
                return this.heroes;
            }
            private set
            {
                this.heroes = value;
            }
        }

        public void AddHero(IHero hero)
        {
            this.heroes.Add(hero.Name, hero);
        }
    }
}
