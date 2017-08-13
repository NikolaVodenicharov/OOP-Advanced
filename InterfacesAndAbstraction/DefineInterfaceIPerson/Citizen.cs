using System;

namespace DefineInterfaceIPerson
{
    public class Citizen : IPerson, IIdentifiable, IBirthable 
    {
        public Citizen (string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public int Age { get; }

        public string Birthday { get; }

        public string Id { get; }

        public string Name { get; }
    }
}
