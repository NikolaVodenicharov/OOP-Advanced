namespace MilitaryElite.Classes
{
    using System;
    using MilitaryElite.Interfaces;
    using System.Collections.Generic;

    public class Mission : IMission
    {
        private static readonly HashSet<string> allowedMissionState = new HashSet<string>
        {
            "inProgress",
            "Finished"
        };

        private string state;

        public Mission (string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; }

        public string State
        {
            get
            {
                return this.state;
            }
            private set
            {
                if (!allowedMissionState.Contains(value))
                {
                    throw new ArgumentException($"{nameof(State)} is invalid.");
                }

                this.state = value;
            }
        }

        public override string ToString()
        {
            var output = $"Code Name: {this.CodeName} State: {this.State}";
            return output;
        }
    }
}
