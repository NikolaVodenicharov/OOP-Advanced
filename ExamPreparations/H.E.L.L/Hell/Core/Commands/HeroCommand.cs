namespace Hell.Core.Commands
{
    using Attributes;
    using Interfaces.Factories;
    using Interfaces.Repositories;

    public class HeroCommand : Command
    {
        private const string HeroCreateMessage = "Created {0} - {1}";

        [CommandInjection]
        IHeroFactory heroFactory;
        [CommandInjection]
        private IHeroRepository heroRepository;

        private string heroName;
        private string typeName;

        public HeroCommand(params string[] parameters)
        {
            this.heroName = parameters[0];
            this.typeName = parameters[1];
        }

        public override string Execute()
        {
            var hero = this.heroFactory.CreateHero(this.heroName, this.typeName);
            this.heroRepository.AddHero(hero);

            var message = string.Format(HeroCreateMessage, this.typeName, this.heroName);
            return message;
        }
    }
}
