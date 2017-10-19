namespace WorkForce.Models.Employees
{
    using System;
    using Interfaces;

    public class StandartEmployee : IEmployee
    {
        private const int DefaultWorkHoursWeekly = 40;

        public StandartEmployee(string name)
        {
            this.Name = name;
            this.WorkHoursWeekly = DefaultWorkHoursWeekly;
        }

        public string Name { get; private set; }

        public int WorkHoursWeekly { get; private set; }
    }
}
