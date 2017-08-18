namespace MilitaryElite.Classes
{
    using System.Collections.Generic;
    using MilitaryElite.Interfaces;
    using System.Text;

    public class Engineer : SpecialisedSoldiers, IEngineer
    {
        public Engineer(string firstName, string lastName, string id, double salary, string corps, IList<IRepair> repairs) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.Repairs = repairs;
        }

        public IList<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(base.ToString())
                  .AppendLine("Repairs:");

            foreach (var rep in this.Repairs)
            {
                output.AppendLine("  " + rep);
            }

            return output.ToString().TrimEnd();
        }
    }
}
