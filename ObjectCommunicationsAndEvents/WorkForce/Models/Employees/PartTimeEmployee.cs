namespace WorkForce.Models.Employees
{
    using System;
    using Interfaces;

    public class PartTimeEmployee : IEmployee
    {
        private const int DefaultWorkHoursWeekly = 20;

        public PartTimeEmployee(string name)
        {
            this.Name = name;
            this.WorkHoursWeekly = DefaultWorkHoursWeekly;
        }

        public string Name { get; private set; }

        public int WorkHoursWeekly { get; private set; }
    }
}
