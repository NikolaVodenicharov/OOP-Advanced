namespace _01.Database
{
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var numbers = new int[] { 3, 5, 8 };
            var database = new Database(numbers);

            database.Add(55);
            database.Remove();
            database.Remove();
            var output = database.Fetch();

        }
    }
}
