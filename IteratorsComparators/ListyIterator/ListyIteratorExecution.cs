using System;
using System.Linq;

public class ListyIteratorExecution
{
    public static void Main()
    {
        var inputElements = Console.ReadLine().Split().Skip(1).ToList();
        var elements = new ListyIterator<string>(inputElements);

        var isContinue = true;
        while (isContinue)
        {
            var command = Console.ReadLine();

            switch (command)
            {
                case "Move":
                    Console.WriteLine(elements.Move());
                    break;
                case "Print":
                    Console.WriteLine(elements.Print());
                    break;
                case "HasNext":
                    Console.WriteLine(elements.HasNext());
                    break;
                case "END":
                    isContinue = false;
                    break;
            }
        }
    }
}
