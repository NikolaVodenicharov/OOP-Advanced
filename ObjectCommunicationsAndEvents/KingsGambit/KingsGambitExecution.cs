namespace KingsGambit
{
    using System.Collections.Generic;
    using Interfaces;
    using IO;
    using Core;
    using Models;

    public class KingsGambitExecution
    {
        public static void Main()
        {
            var servants = new List<IServant>();
            var consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();
            var kingName = consoleReader.ReadLine();
            var king = new King(kingName);
            var engine = new Engine(servants, consoleReader, consoleWriter, king);
            engine.Run();     
        }
    }
}
