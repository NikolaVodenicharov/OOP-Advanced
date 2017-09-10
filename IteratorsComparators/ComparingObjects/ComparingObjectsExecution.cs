namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class ComparingObjectsExecution
    {
        public static void Main()
        {
            var persons = new List<Person>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                persons.Add(
                    CreatePerson(inputLine));
            }

            var collectionIndex = int.Parse(Console.ReadLine());
            string output = CreateOutput(
                persons, 
                collectionIndex);
            Console.WriteLine(output);
        }

        private static string CreateOutput(List<Person> persons, int collectionIndex)
        {
            var output = string.Empty;

            if (collectionIndex < persons.Count)
            {
                var totalPeople = persons.Count;
                int equalPeople = FindEqualPeople(
                    persons, 
                    collectionIndex);
                var notEqualPeople = totalPeople - equalPeople;

                output = $"{equalPeople} {notEqualPeople} {totalPeople}";
            }
            else
            {
                output = "No matches";
            }

            return output;
        }

        private static int FindEqualPeople(List<Person> persons, int collectionIndex)
        {
            var equalPeople = 0;
            var targetPerson = persons[collectionIndex];
            foreach (var person in persons)
            {
                if (person.CompareTo(targetPerson) == 0)
                {
                    equalPeople++;
                }
            }

            return equalPeople;
        }

        private static Person CreatePerson(string inputLine)
        {
            var splitedInput = inputLine.Split();

            var name = splitedInput[0];
            var age = int.Parse(splitedInput[1]);
            var town = splitedInput[2];

            var person = new Person(name, age, town);
            return person;
        }
    }
}
