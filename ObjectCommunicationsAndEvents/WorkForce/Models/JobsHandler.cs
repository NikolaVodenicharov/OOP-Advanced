namespace WorkForce.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JobsHandler
    {
        public JobsHandler(ICollection<IJob> jobs)
        {
            this.UnfinishedJobs = jobs;
        }

        private ICollection<IJob> UnfinishedJobs { get; set; }

        public void AddAndSubscribe(IJob job)
        {
            if (job == null)
            {
                throw new ArgumentNullException("Job can not be null");
            }
            this.SubscribeToJobDone(job);
            this.Add(job);
        }
        public void HandleJobDoneEvent(object sender, EventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("Event can not be null");
            }

            var job = (IJob)sender;
            this.Remove(job);
            this.PrintFinishedJob(job);
            this.UnsubscribeJobDone(job);
        }
        public void PassWeek()
        {
            var jobsCopy = this.UnfinishedJobs.ToArray();
            for (int i = 0; i < jobsCopy.Length; i++)
            {
                jobsCopy[i].UpdateWorkProgress();
            }
        }
        public void PrintStatus()
        {
            if (this.UnfinishedJobs.Count != 0)
            {
                foreach (var job in this.UnfinishedJobs)
                {
                    Console.WriteLine(job);
                }
            }
        }

        private void Add(IJob job)
        {
            this.UnfinishedJobs.Add(job);
        }
        private void SubscribeToJobDone(IJob job)
        {
            job.JobDone += this.HandleJobDoneEvent;
        }

        private void Remove(IJob job)
        {
            if (!this.UnfinishedJobs.Contains(job))
            {
                throw new ArgumentException($"{job.ToString()} does not exist in collection");
            }

            this.UnfinishedJobs.Remove(job);
        }
        private void PrintFinishedJob(IJob job)
        {
            Console.WriteLine($"Job {job.Name} done!");
        }
        private void UnsubscribeJobDone(IJob job)
        {
            job.JobDone -= this.HandleJobDoneEvent;
        }
    }
}
