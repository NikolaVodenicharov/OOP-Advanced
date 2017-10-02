namespace _01HarestingFields
{
    using System;
    using System.Text;
    using System.Reflection;
    using System.Linq;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);
            var answer = new StringBuilder();
            ExecuteCommands(type, answer);

            Console.WriteLine(answer.ToString().TrimEnd());
        }

        public static void ExecuteCommands(Type type, StringBuilder answer)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "HARVEST")
                {
                    break;
                }

                switch (input)
                {
                    case "private":
                        answer.AppendLine(ExtractFieldInfo(GetPrivateFields(type)));
                        break;
                    case "protected":
                        answer.AppendLine(ExtractFieldInfo(GetProtectedFields(type)));
                        break;
                    case "public":
                        answer.AppendLine(ExtractFieldInfo(GetPublicFields(type)));
                        break;
                    case "all":
                        answer.AppendLine(ExtractFieldInfo(GetAllFields(type)));
                        break;
                    default:
                        throw new ArgumentException("Invalid command");
                }
            }
        }

        public static string ExtractFieldInfo(FieldInfo[] fields)
        {
            var output = new StringBuilder();
            foreach (var field in fields)
            {
                output.AppendFormat("{0} {1} {2}"
                    , field.Attributes.ToString().ToLower().Replace("family", "protected")
                    , field.FieldType.Name
                    , field.Name
                    + Environment.NewLine);
            }

            return output.ToString().TrimEnd(); 
        }

        public static FieldInfo[] GetAllFields(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return fields;
        }
        public static FieldInfo[] GetPrivateFields(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.IsPrivate).ToArray();
            return fields;
        }
        public static FieldInfo[] GetProtectedFields(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.IsFamily).ToArray();
            return fields;
        }
        public static FieldInfo[] GetPublicFields(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            return fields;
        }
    }
}
