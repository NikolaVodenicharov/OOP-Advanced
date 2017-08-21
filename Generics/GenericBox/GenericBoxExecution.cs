
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericBoxExecution
    {
        public static void Main()
        {
            var lines = new List<Box<string>>();

            var inputLinesNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLinesNumber; i++)
            {
                var line = new Box<string>(Console.ReadLine());
                lines.Add(line);
            }

            var comparedLine = Console.ReadLine();

            Console.WriteLine(CounterOfBigger(lines, comparedLine));
        }


        public static int CounterOfBigger<T> 
            (List<Box<T>> lines, T comparedLine)
            where T : IComparable
        {
            var counter = 0;

            foreach (var line in lines)
            {
                if (line.Data.CompareTo(comparedLine) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }

