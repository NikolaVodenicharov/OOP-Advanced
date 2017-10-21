namespace Problem1Logger.Entities
{
    using System;
    using Interfaces;
    using System.Collections.Generic;
    using Enumerations;
    using System.Linq;

    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public ICollection<IAppender> Appenders { get; private set; }

        private void Log(string timeStamp, ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.Appenders)
            {
                if (appender.ReportLevel <= reportLevel)
                {
                    appender.Append(timeStamp, reportLevel, message);
                }
            }
        }

        public void Info(string timeStamp, string message)
        {
            Log(timeStamp, ReportLevel.Info, message);
        }
        public void Warn(string timeStamp, string message)
        {
            Log(timeStamp, ReportLevel.Warn, message);
        }
        public void Error(string timeStamp, string message)
        {
            Log(timeStamp, ReportLevel.Error, message);
        }
        public void Critical(string timeStamp, string message)
        {
            Log(timeStamp, ReportLevel.Critical, message);
        }
        public void Fatal(string timeStamp, string message)
        {
            Log(timeStamp, ReportLevel.Fatal, message);
        }
    }
}
