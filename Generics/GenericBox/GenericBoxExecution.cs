namespace GenericBox
{
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

            var inputIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var index1 = inputIndexes[0];
            var index2 = inputIndexes[1];

            var temporary = lines[index1];
            lines[index1] = lines[index2];
            lines[index2] = temporary;

            foreach (var str in lines)
            {
                Console.WriteLine(str);
            }
        }
    }
}
