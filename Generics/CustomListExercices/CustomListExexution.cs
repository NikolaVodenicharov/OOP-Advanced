namespace CustomListExercices
{
    using System;
    using System.Text;
    using System.Linq;

    public class CustomListExexution
    {
        public static void Main()
        {
            var list = new CustomList<string>();

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
                        list.Add(addElement);
                        break;
                    case "Remove":
                        var removeIndex = int.Parse(splitInput[1]);
                        list.Remove(removeIndex);
                        break;
                    case "Contains":
                        var containElement= splitInput[1];
                        Console.WriteLine(list.Contains(containElement));
                        break;
                    case "Swap":
                        var swapIndex1 = int.Parse(splitInput[1]);
                        var swapIndex2 = int.Parse(splitInput[2]);
                        list.Swap(swapIndex1, swapIndex2);
                        break;
                    case "Greater":
                        var greaterThanElement = splitInput[1];
                        Console.WriteLine(list.CountGreaterThan(greaterThanElement));
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Print":
                        var sb = new StringBuilder();

                        Console.WriteLine(sb.ToString().TrimEnd());
                        break;
                }
            }
        }
    }
}
