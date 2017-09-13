
    using System.Collections.Generic;

    public class WeeklyCalendar
    {
        public WeeklyCalendar()
        {
            this.WeeklySchedule = new List<WeeklyEntry>();
        }

        public List<WeeklyEntry> WeeklySchedule { get;}

        public void AddEntry(string weekday, string notes)
        {
            var weklyEntry = new WeeklyEntry(weekday, notes);
            this.WeeklySchedule.Add(weklyEntry);
        }
    }

