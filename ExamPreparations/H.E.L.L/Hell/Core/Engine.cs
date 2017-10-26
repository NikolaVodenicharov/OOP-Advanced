namespace Hell.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces.IO;
    using IO;
    using Interfaces.Core;

    public class Engine
    {
        private const string EndReadingKeyword = "Quit";

        private IReader reader;
        private IWriter writer;
        private ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                var inputLine = this.reader.ReadLine();
                var arguments = this.SplitString(inputLine, new char[] { ' ' });
                var command = this.commandInterpreter.InterpredCommand(arguments);
                var output = command.Execute();

                this.writer.WriteLine(output);

                var isEndReading = inputLine.Equals(EndReadingKeyword);
                if (isEndReading) { break; }
            }
        }

        private string[] SplitString(string text, params char[] splitBy)
        {
            if (text == null || splitBy == null)
            {
                throw new ArgumentNullException("Input parameters can not be null");
            }

            var splited = text.Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
            return splited;
        }
    }
}