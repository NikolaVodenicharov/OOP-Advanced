namespace KingsGambit.IO
{
    using Interfaces;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            var output = Console.ReadLine();
            return output;
        }
    }
}
