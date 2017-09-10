namespace ComparingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person (string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            int result = 0;

            if(this.Name != other.Name)
            {
                result = this.Name.CompareTo(other.Name);
            }
            else if (this.Age != other.Age)
            {
                result = this.Age - other.Age;
            }
            else
            {
                result = this.Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}
