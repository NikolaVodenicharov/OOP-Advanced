namespace WorkForce
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models.Employees;
    using System.Linq;
    using Models;
    using Core;

    public class WorkForceExecution
    {
        public static void Main()
        {
            var employees = new List<IEmployee>();
            var jobs = new JobsHandler(new List<IJob>());
            var engine = new Engine(employees, jobs);
            engine.Run();            
        }
    }
}
