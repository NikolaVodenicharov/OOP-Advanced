namespace WorkForce.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models.Employees;
    using Models;

    public class Engine
    {
        private ICollection<IEmployee> employees;
        private JobsHandler jobs;

        public Engine(ICollection<IEmployee> employees, JobsHandler jobs)
        {
            this.employees = employees;
            this.jobs = jobs;
        }

        public void Run()
        {
            while (true)
            {
                var inputLine = Console.ReadLine().Split();
                var command = inputLine[0];

                if (command == "End")
                {
                    break;
                }
                else if (command == "StandartEmployee")
                {
                    //CreateStandartEmployee()
                    var employeeName = inputLine[1];
                    var employee = new StandartEmployee(employeeName);

                    employees.Add(employee);
                }
                else if (command == "PartTimeEmployee")
                {
                    //CreatePartTimeEpmloyee()
                    var employeeName = inputLine[1];
                    var employee = new PartTimeEmployee(employeeName);

                    employees.Add(employee);
                }
                else if (command == "Job")
                {
                    // CreateJob()
                    var jobName = inputLine[1];
                    var hoursRequired = int.Parse(inputLine[2]);
                    var employeeName = inputLine[3];

                    var employee = employees.First(x => x.Name == employeeName);

                    var job = new Job(jobName, hoursRequired, employee);


                    jobs.AddAndSubscribe(job);
                }
                else if (command == "Pass")
                {
                    jobs.PassWeek();
                }
                else if (command == "Status")
                {
                    jobs.PrintStatus();
                }
            }
        }
    }
}
