
    using System;
    using System.Collections.Generic;

    public class WeeklyEntry : IComparable<WeeklyEntry>
    {
        public WeeklyEntry(string weekday, string notes)
        {
            this.Weekday = (WeekDay)Enum.Parse(typeof(WeekDay), weekday);
            this.Notes = notes;
        }

        public WeekDay Weekday { get; private set; }
        public string Notes { get; private set; }

        public override string ToString()
        {
            var output = $"{this.Weekday} - {this.Notes}";
            return output;
        }

        public int CompareTo(WeeklyEntry other)
        {
            var result = 0;

            if (ReferenceEquals(this, other))
            {
                result = 0;
            }
            else if (ReferenceEquals(null, other))
            {
                result = 1;
            }
            else
            {
                result = Weekday.CompareTo(other.Weekday);
            }

            if (result == 0)
            {
                result = string.Compare(this.Notes, other.Notes, StringComparison.Ordinal);
            }

            return result;
        }
    }

