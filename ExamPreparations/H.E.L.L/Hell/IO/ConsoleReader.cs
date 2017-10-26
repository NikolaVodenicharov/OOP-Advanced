namespace Hell.IO
{
    using Hell.Interfaces.IO;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            var line = Console.ReadLine();
            return line;
        }
    }
}