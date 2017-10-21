namespace Problem1Logger.Entities.Layouts
{
    using Interfaces;
    using System;
    using Enumerations;

    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string timeStamp, ReportLevel reportLevel, string message)
        {
            var output = $"{timeStamp} - {reportLevel} - {message}";
            return output;
        }
    }
}
