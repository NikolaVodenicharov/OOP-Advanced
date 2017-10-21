namespace Problem1Logger.Entities
{
    using System;
    using System.Text;
    using System.Linq;
    using System.IO;

    public class LogFile
    {
        private const string DefaultFullName = "log.txt";
        private StringBuilder stringBuilder;

        public LogFile()
        {
            this.stringBuilder = new StringBuilder();
        }

        public int Size
        {
            get
            {
                return CalculateSize();
            }
        }

        private int CalculateSize()
        {
            int count =
                this.stringBuilder
                .ToString()
                .Where(c => char.IsLetter(c))
                .Sum(c => c);

            return count;
        }

        public void Write (string message)
        {
            WriteToStringBuilder(message);
            WriteToFile(message);
        }

        private static void WriteToFile(string message)
        {
            File.AppendAllText(DefaultFullName, message + Environment.NewLine);
        }

        private void WriteToStringBuilder(string message)
        {
            this.stringBuilder.AppendLine(message);
        }
    }
}
