namespace BorderControl
{
    using System;

    public class Citizen : IIdentifiable, IBirthdate, IName
    {
        private string age;

        public Citizen (string name, string age, string id, string dateOfBirth)
        {
            this.age = age;
            this.Name = name;
            this.Id = id;
            this.DateOfBirth = dateOfBirth;
        }

        public string Id { get; }

        public string DateOfBirth { get; }

        public string Name { get; }
    }
}
