namespace StrategyPattern
{
    using System.Collections.Generic;

    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int xLen = x.Name.Length;
            int yLen = y.Name.Length;

            int result = xLen - yLen;

            if (result == 0)
            {
                char xFirst = char.ToLower(x.Name[0]);
                char yFirst = char.ToLower(y.Name[0]);

                result = xFirst.CompareTo(yFirst);
            }

            return result;
        }
    }
}
