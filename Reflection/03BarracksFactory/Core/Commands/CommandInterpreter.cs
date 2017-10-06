namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;
    using System.Reflection;
    using System.Linq;

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

            return 
                (IExecutable)Activator
                .CreateInstance(
                    type, 
                    new object[] 
                    {
                        data,
                        this.repository,
                        this.unitFactory
                    });
        }
    }
}
