namespace Problem1Logger.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ILogger
    {
        ICollection<IAppender> Appenders { get; }

        void Info(string timeStamp, string message);
        void Warn(string timeStamp, string message);
        void Error(string timeStamp, string message);
        void Critical(string timeStamp, string message);
        void Fatal(string timeStamp, string message);
    }
}
