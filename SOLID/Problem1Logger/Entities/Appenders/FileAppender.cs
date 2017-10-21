namespace Problem1Logger.Entities.Appenders
{
    using Interfaces;
    using System;
    using Enumerations;

    public class FileAppender : IAppender
    {
        private LogFile file;

        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
            this.file = new LogFile();
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string timeStamp, ReportLevel reportLevel, string message)
        {
            var formattedMessage = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            this.file.Write(formattedMessage);
        }
    }
}
