namespace MilitaryElite.Classes
{
    using System;
    using System.Collections.Generic;
    using MilitaryElite.Interfaces;
    using System.Text;

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(string firstName, string lastName, string id, double salary, IList<ISoldier> privates) 
            : base(firstName, lastName, id, salary)
        {
            this.Privates = privates;
        }

        public IList<ISoldier> Privates { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(base.ToString())
                  .AppendLine("Privates:");

            foreach (var p in this.Privates)
            {
                output.AppendLine("  " + p.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
