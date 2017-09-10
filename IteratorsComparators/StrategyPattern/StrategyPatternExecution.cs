namespace StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StrategyPatternExecution
    {
        public static void Main()
        {
            var personNameSorted = new SortedSet<Person>(new PersonNameComparer());
            var personAgeSorted = new SortedSet<Person>(new PersonAgeComparer());

            ConsoleReadToCollections(personNameSorted, personAgeSorted);

            string answer = ExtractAnswer(personNameSorted, personAgeSorted);
            Console.WriteLine(answer);
        }

        private static void ConsoleReadToCollections(SortedSet<Person> personNameSorted, SortedSet<Person> personAgeSorted)
        {
            int linesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesNumber; i++)
            {
                var inputLine = Console.ReadLine().Split();

                var name = inputLine[0];
                var age = int.Parse(inputLine[1]);
                var person = new Person(name, age);

                personNameSorted.Add(person);
                personAgeSorted.Add(person);
            }
        }

        private static string ExtractAnswer(SortedSet<Person> personNameSorted, SortedSet<Person> personAgeSorted)
        {
            var output = new StringBuilder();

            foreach (var person in personNameSorted)
            {
                output.AppendLine(person.ToString());
            }

            foreach (var person in personAgeSorted)
            {
                output.AppendLine(person.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
