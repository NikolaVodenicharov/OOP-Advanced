namespace CustomListExercices
{
    using System;
    using System.Text;
    using System.Linq;

    public class CustomListExexution
    {
        public static void Main()
        {
            var elements = new CustomList<string>();

            while (true)
            {
                var input = Console.ReadLine();

                bool stopLoop = input.Equals("End", StringComparison.OrdinalIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                var splitInput = input.Split();

                switch (splitInput[0])
                {
                    case "Add":
                        var addElement = splitInput[1];
                        elements.Add(addElement);
                        break;
                    case "Remove":
                        var removeIndex = int.Parse(splitInput[1]);
                        elements.Remove(removeIndex);
                        break;
                    case "Contains":
                        var containElement= splitInput[1];
                        Console.WriteLine(elements.Contains(containElement));
                        break;
                    case "Swap":
                        var swapIndex1 = int.Parse(splitInput[1]);
                        var swapIndex2 = int.Parse(splitInput[2]);
                        elements.Swap(swapIndex1, swapIndex2);
                        break;
                    case "Greater":
                        var greaterThanElement = splitInput[1];
                        Console.WriteLine(elements.CountGreaterThan(greaterThanElement));
                        break;
                    case "Max":
                        Console.WriteLine(elements.Max());
                        break;
                    case "Min":
                        Console.WriteLine(elements.Min());
                        break;
                    case "Print":
                        var output = new StringBuilder();
                        foreach (var element in elements)
                        {
                            output.AppendLine(element);
                        }
                        Console.WriteLine(output.ToString().TrimEnd());
                        break;
                }
            }
        }
    }
}
