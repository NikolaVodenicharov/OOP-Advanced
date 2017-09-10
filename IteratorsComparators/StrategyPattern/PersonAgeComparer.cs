namespace StrategyPattern
{
    using System.Collections.Generic;

    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Age - y.Age;

            return result;
        }
    }
}
