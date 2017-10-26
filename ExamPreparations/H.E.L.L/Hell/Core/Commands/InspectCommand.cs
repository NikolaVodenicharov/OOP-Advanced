namespace Hell.Core.Commands
{
    using System;

    using Attributes;
    using Interfaces.Repositories;

    public class InspectCommand : Command
    {
        [CommandInjection]
        private IHeroRepository heroRepository;

        private string heroName;

        public InspectCommand(params string[] parameters)
        {
            this.heroName = parameters[0];
        }
        public override string Execute()
        {
            var message = this.heroRepository.Heroes[heroName].ToString();
            return message;
        }
    }
}
