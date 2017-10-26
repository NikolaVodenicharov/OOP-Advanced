namespace RecyclingStation.BusinessLayer.IO
{
    using System;
    using Contracts.IO;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            var line = Console.ReadLine();
            return line;
        }
    }
}
