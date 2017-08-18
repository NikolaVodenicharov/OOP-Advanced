namespace MilitaryElite.Classes
{
    using MilitaryElite.Interfaces;

    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, string id, double salary) 
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public double Salary { get; private set; }

        public override string ToString()
        {
            var output = base.ToString() + " " + $"Salary: {this.Salary:f2}";
            return output;
        }
    }
}
