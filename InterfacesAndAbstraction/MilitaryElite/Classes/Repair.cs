namespace MilitaryElite.Classes
{
    using MilitaryElite.Interfaces;

    public class Repair : IRepair
    {
        public Repair (string hoursWorked, string partName)
        {
            this.HoursWorked = hoursWorked;
            this.PartName = partName;
        }

        public string HoursWorked { get; private set; }

        public string PartName { get; private set; }

        public override string ToString()
        {
            var output = $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
            return output;
        }
    }
}
