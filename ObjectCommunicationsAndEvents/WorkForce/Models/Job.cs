namespace WorkForce.Models
{
    using System;
    using WorkForce.Interfaces;

    public class Job : IJob
    {
        public event EventHandler JobDone;

        public Job(string name, int workHoursRequired, IEmployee employee)
        {
            this.Name = name;
            this.WorkHoursRequired = workHoursRequired;
            this.EmployeeName = employee;
        }

        public string Name { get; private set; }
        public int WorkHoursRequired { get; private set; }
        public IEmployee EmployeeName { get; private set; }

        public void UpdateWorkProgress ()
        {
            this.ReduceRequiredHours();
            this.JobDoneHandler();
        }

        private void ReduceRequiredHours()
        {
            this.WorkHoursRequired -= this.EmployeeName.WorkHoursWeekly;
        }

        private void JobDoneHandler()
        {
            var isDone = this.IsJobDone();
            if (isDone)
            {
                this.TriggerJobDoneEvent();
            }
        }
        private bool IsJobDone()
        {
            if (this.WorkHoursRequired <= 0)
            {
                return true;
            }

            return false;
        }
        private void TriggerJobDoneEvent()
        {
            if (this.JobDone != null)
            {
                this.JobDone(this, null);
            }
        }

        public override string ToString()
        {
            var result = $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}";
            return result;
        }
    }
}
