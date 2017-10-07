namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;

    public class Fight : Command
    {
        public Fight(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
