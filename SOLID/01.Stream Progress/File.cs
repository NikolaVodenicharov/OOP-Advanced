namespace _01.Stream_Progress
{
    using _01.Stream_Progress.Interfaces;

    public class File : IStream
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}