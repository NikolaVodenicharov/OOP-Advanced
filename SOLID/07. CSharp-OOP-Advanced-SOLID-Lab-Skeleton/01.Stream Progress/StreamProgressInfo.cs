namespace _01.Stream_Progress
{
    using _01.Stream_Progress.Interfaces;

    public class StreamProgressInfo
    {
        private IStream stream;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStream stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (this.stream.BytesSent * 100) / this.stream.Length;
        }
    }
}