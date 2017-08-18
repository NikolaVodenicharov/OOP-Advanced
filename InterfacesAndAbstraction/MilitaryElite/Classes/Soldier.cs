namespace MilitaryElite.Classes
{
    using MilitaryElite.Interfaces;

    public abstract class Soldier : ISoldier
    {
        public Soldier (string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName { get; private set; }

        public string Id { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            var output = $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
            return output;
        }
    }
}
