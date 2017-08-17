namespace BorderControl
{
    using System;

    public class Citizen : IIdentifiable, IBirthdate, IHuman, IBuyer
    {
        public Citizen (string name, string age, string id, string dateOfBirth)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.DateOfBirth = dateOfBirth;
            this.Food = 0;
        }

        public string Name { get; set; }

        public string Age { get; }

        public string Id { get; }

        public string DateOfBirth { get; }

        public double Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
