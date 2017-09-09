namespace Froggy
{
    using System;
    using System.Linq;

    public class FroggyExecution
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var lake = new Lake(input);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
