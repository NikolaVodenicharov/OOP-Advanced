namespace KingsGambit.IO
{
    using System;
    using KingsGambit.Interfaces;

    public class ConsoleWriter : IWrite
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
