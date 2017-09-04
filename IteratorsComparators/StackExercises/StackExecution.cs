namespace StackExercises
{
    using System;
    using System.Text;

    public class StackExecution
    {
        public static void Main()
        {
            var elements = new Stack<int>();

            bool isContinue = true;
            while (isContinue)
            {
                var input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                switch (input[0])
                {
                    case "Pop":
                        RemoveElement(elements);
                        break;
                    case "Push":
                        AddElements(elements, input);
                        break;
                    case "END":
                        isContinue = false;
                        break;
                }
            }

            PrintElements(elements);
        }

        public static void PrintElements(Stack<int> elements)
        {
            var output = new StringBuilder();

            foreach (var element in elements)
            {
                output.AppendLine(element.ToString());
            }

            output.Append(output);

            Console.WriteLine(output.ToString().TrimEnd());
        }

        public static void RemoveElement(Stack<int> elements)
        {
            try
            {
                elements.Pop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void AddElements(Stack<int> elements, string[] input)
        {
            var elementsForAdding = ExtractElements(input);

            foreach (var item in elementsForAdding)
            {
                elements.Push(item);
            }
        }

        public static int[] ExtractElements(string[] input)
        {
            var len = input.Length - 1;
            int[] collection = new int[len];

            for (int i = 0; i < len; i++)
            {
                var parsingElement = input[i + 1];
                var parsedElement = int.Parse(parsingElement);
                collection[i] = parsedElement;
            }

            return collection;
        }
    }
}
