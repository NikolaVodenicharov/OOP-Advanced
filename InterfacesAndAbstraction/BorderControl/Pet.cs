using System;

namespace BorderControl
{
    public class Pet : IBirthdate, IName
    {
        public Pet (string name, string dateOfBirt)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirt;
        }

        public string DateOfBirth { get; }

        public string Name { get; }
    }
}
