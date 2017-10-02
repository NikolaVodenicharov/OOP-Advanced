namespace _02BlackBoxInteger
{
    using System;
    using System.Reflection;
    using System.Text;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var blackBoxType = typeof(BlackBoxInt);
            var blackBox = (BlackBoxInt)Activator.CreateInstance(blackBoxType, true);
            var methods = blackBoxType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var output = new StringBuilder();

            while (true)
            {
                var input = Console.ReadLine().Split('_');
                if (input[0].Equals("END"))
                {
                    break;
                }

                var command = input[0];
                var value = int.Parse(input[1]);

                blackBoxType
                    .GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(blackBox, new object[] { value });

                output.Append(blackBoxType
                    .GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(blackBox))
                    .AppendLine();
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }
    }
}
