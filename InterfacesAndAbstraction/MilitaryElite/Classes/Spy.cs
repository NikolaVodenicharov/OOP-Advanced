namespace MilitaryElite.Classes
{
    using MilitaryElite.Interfaces;
    using System.Text;

    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, string id, int code) 
            : base(firstName, lastName, id)
        {
            this.Code = code;
        }

        public int Code { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(base.ToString())
                  .Append($"Code Number: {this.Code}");

            return output.ToString();
        }
    }
}
