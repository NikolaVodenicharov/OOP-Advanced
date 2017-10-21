namespace Problem1Logger.Entities.Layouts
{
    using Interfaces;
    using System;
    using Enumerations;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(string timeStamp, ReportLevel reportLevel, string message)
        {
            var formattedMessage = new StringBuilder();
            formattedMessage
                .AppendLine("<log>")
                .AppendLine($"<date>{timeStamp}</date>")
                .AppendLine($"<level>{reportLevel}</level>")
                .AppendLine($"<message>{message}</message>")
                .AppendLine("</log>");

            var output = formattedMessage.ToString().TrimEnd();
            return output;
        }
    }
}
