namespace MilitaryElite.Classes
{
    using System;
    using MilitaryElite.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public abstract class SpecialisedSoldiers : Private, ISpecialisedSoldier
    {
        private static readonly HashSet<string> allowedCorps = new HashSet<string>
        {
            "Airforces",
            "Marines"
        };

        private string corps;

        public SpecialisedSoldiers(string firstName, string lastName, string id, double salary, string corps) 
            : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }
        
        public string Corps
        {
            get
            {
                return this.corps;
            }
            private set
            {
                if (!allowedCorps.Contains(value))
                {
                    throw new ArgumentException($"{nameof(Corps)} is not valid.");
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString())
                  .Append($"Corps: {this.Corps}");

            return output.ToString();
        }
    }
}
