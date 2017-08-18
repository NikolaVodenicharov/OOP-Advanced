namespace MilitaryElite.Classes
{
    using System;
    using System.Collections.Generic;
    using MilitaryElite.Interfaces;
    using System.Text;

    public class Commando : SpecialisedSoldiers, ICommando
    {
        public Commando(string firstName, string lastName, string id, double salary, string corps, IList<IMission> missions) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.Missions = missions;
        }

        public IList<IMission> Missions { get; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(base.ToString())
                  .AppendLine("Missions:");

            foreach (var m in this.Missions)
            {
                output.AppendLine("  " + m);
            }

            return output.ToString().TrimEnd();
        }
    }
}
