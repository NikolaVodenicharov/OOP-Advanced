namespace Problem1Logger.Interfaces
{
    using Enumerations;
    using System;

    public interface ILayout
    {
        string FormatMessage(string timeStamp, ReportLevel reportLevel, string message);
    }
}
