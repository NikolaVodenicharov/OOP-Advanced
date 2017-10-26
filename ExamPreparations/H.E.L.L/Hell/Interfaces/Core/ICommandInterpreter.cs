namespace Hell.Interfaces.Core
{
    using System;
    using Commands;

    public interface ICommandInterpreter
    {
        IExecutable InterpredCommand(string[] inputParameters);
    }
}
