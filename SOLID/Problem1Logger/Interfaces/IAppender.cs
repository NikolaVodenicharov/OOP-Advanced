namespace Problem1Logger.Interfaces
{
    using Enumerations;
    using System;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string timeStamp, ReportLevel reportLevel, string message);
    }
}
