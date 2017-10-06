namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    var data = Console.ReadLine().Split();
                    var commandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data[0]);

                    var result = this.commandInterpreter.InterpretCommand(data, commandName).Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
