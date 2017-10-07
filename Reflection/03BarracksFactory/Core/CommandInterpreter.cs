namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;
    using System.Reflection;
    using System.Linq;
    using Attributes;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var type =
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == commandName);

            var command = (IExecutable)Activator.CreateInstance(type, new object[] { data });
            command = this.InjectDependancy(command);

            return command;
        }

        private IExecutable InjectDependancy (IExecutable command)
        {
            var commandFields = 
                command
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
                .ToArray();
            var interpreterFields = 
                this
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

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
