namespace _01.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private const int containerCapacity = 16;
        private Person[] persons;
        private int currentIndex;

        public Database(ICollection<Person> person)
        {
            this.Persons = person;
        }

        public ICollection<Person> Persons
        {
            get
            {
                var output = new List<Person>();
                for (int i = 0; i <= this.currentIndex; i++)
                {
                    output.Add(this.persons[i]);
                }

                return output;
            }
            private set
            {
                if (value == null) { throw new InvalidOperationException(); }

                this.persons = new Person[containerCapacity];
                this.currentIndex = -1;

                foreach (var person in value)
                {
                    this.Add(person);
                }
            }
        }

        public void Add(Person person)
        {
            for (int i = 0; i <= this.currentIndex; i++)
            {
                var isUsernameExist = person.Username == this.persons[i].Username;
                if (isUsernameExist) { throw new InvalidOperationException("Username exist."); }

                var isIdExist = person.Id == this.persons[i].Id;
                if (isIdExist) { throw new InvalidOperationException("ID exist."); }
            }

            var isCapacityFull = this.currentIndex + 1 == containerCapacity;
            if (isCapacityFull) { throw new InvalidOperationException("Capacity is full."); }

            this.persons[this.currentIndex + 1] = person;
            this.currentIndex++;

        }
        public void Remove()
        {
            var isEmptyCollection = this.currentIndex < 0;
            if (isEmptyCollection) { throw new InvalidOperationException(); }

            this.persons[currentIndex] = null;
            this.currentIndex--;
        }
        public Person FindByUsername(string username)
        {
            bool isInputNull = username == null;
            if (isInputNull) { throw new ArgumentNullException("Input username can't be null"); }

            for (int i = 0; i <= currentIndex; i++)
            {
                if (username == this.persons[i].Username)
                {
                    return this.persons[i];
                }
            }

            throw new InvalidOperationException("No such person exist.");
        }
        public Person FindById(string id)
        {
            bool isIdNegative = id[0] == '-';
            if (isIdNegative) { throw new ArgumentOutOfRangeException("ID can't be negative number"); }

            for (int i = 0; i <= currentIndex; i++)
            {
                if (id == this.persons[i].Id)
                {
                    return this.persons[i];
                }
            }

            throw new InvalidOperationException("No such person exist.");
        }
    }
}
