namespace _01.Stream_Progress.Interfaces
{
    public interface IStream
    {
        int Length { get; set; }
        
        int BytesSent { get; set; }
    }
}
