namespace RecyclingStation.BusinessLayer.Contracts.IO
{
    using System;

    public interface IWriter
    {
        void WriteAllText(string text);
    }
}
