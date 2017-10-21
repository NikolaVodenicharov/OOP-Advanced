namespace Problem1Logger
{
    using Entities;
    using Entities.Appenders;
    using Entities.Layouts;
    using Enumerations;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class LoggerExecution
    {
        public static void Main()
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);
            var logger = new Logger(consoleAppender);

            logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

        }
    }
}
