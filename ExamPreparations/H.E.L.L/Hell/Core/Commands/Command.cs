namespace Hell.Core.Commands
{
    using System;
    using Hell.Interfaces.Core.Commands;

    public abstract class Command : IExecutable
    {
        public abstract string Execute();
    }
}
