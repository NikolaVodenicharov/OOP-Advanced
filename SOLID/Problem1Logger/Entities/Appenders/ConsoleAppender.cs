namespace Problem1Logger.Entities.Appenders
{
    using System;
    using Enumerations;
    using Interfaces;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.Info;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string timeStamp, ReportLevel reportLevel, string message)
        {
            var formattedMessage = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            Console.WriteLine(formattedMessage);
        }
    }
}
