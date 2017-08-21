namespace GenericBox
{
    using System;

    public class GenericBoxExecution
    {
        public static void Main()
        {
            var inputLinesNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLinesNumber; i++)
            {
                var str = new Box<int>(int.Parse(Console.ReadLine()));

                Console.WriteLine(str);
            }
        }
    }
}
