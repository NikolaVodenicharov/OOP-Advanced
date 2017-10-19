namespace WorkForce.Interfaces
{
    using System;

    public interface IJob
    {
        event EventHandler JobDone;

        string Name { get; }
        int WorkHoursRequired { get; }

        void UpdateWorkProgress();
    }
}
