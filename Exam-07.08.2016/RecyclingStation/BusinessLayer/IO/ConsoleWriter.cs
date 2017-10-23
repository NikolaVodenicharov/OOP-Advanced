namespace RecyclingStation.BusinessLayer.IO
{
    using System;
    using Contracts.IO;

    public class ConsoleWriter : IWriter
    {
        public void WriteAllText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
