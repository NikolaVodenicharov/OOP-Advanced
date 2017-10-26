namespace Hell.Core
{
    using System;
    using System.Reflection;
    using System.Linq;

    using Interfaces.Core.Commands;
    using Interfaces.Core;
    using Interfaces.Repositories;
    using Interfaces.Factories;
    using Attributes;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSufix = "Command";
        IHeroRepository heroRepository;
        IHeroFactory heroFactory;
        IItemFactory itemFactory;
        IRecipeFactory recipeFactory;

        public CommandInterpreter(
            IHeroRepository heroRepository, 
            IHeroFactory heroFactory, 
            IItemFactory itemFactory,
            IRecipeFactory recipeFactory)
        {
            this.heroRepository = heroRepository;
            this.heroFactory = heroFactory;
            this.itemFactory = itemFactory;
            this.recipeFactory = recipeFactory;
        }

        public IExecutable InterpredCommand(string[] inputParameters)
        {
            IExecutable command = CreateCommand(inputParameters);
            command = this.InjectDependancy(command);
            return command;
        }

        private IExecutable CreateCommand(string[] inputParameters)
        {
            var name =
                inputParameters[0] +
                CommandSufix;
            var type =
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(x => x.Name == name);
            //if somehow are parameters null, or empty ?
            var parameters =
                inputParameters
                .Skip(1)
                .Take(inputParameters.Length - 1)
                .ToArray();
            var command =
                Activator
                .CreateInstance(type, parameters)
                as IExecutable;

            return command;
        }

        private IExecutable InjectDependancy(IExecutable command)
        {
            var interpreterFields =
                this
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var commandFields =
                command
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute<CommandInjectionAttribute>() != null)
                .ToArray();

            foreach (var commandField in commandFields)
            {
                var injectValue =
                    interpreterFields
                    .First(f => f.FieldType == commandField.FieldType)
                    .GetValue(this);
                commandField.SetValue(command, injectValue);
            }

            return command;
        }
    }
}
