namespace Stealer
{
    using System;
    using System.Reflection;
    using System.Text;
    using System.Linq;

    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            var output = new StringBuilder();
            output.AppendLine($"Class under investigation: {investigatedClass}");

            var classType = Type.GetType(investigatedClass);
            var classFields = classType.GetFields(
                BindingFlags.Instance | 
                BindingFlags.Public | 
                BindingFlags.NonPublic | 
                BindingFlags.Static);

            var classInstance = Activator.CreateInstance(classType);

            foreach (var field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                output.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return output.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string investigatedClass)
        {
            var output = new StringBuilder();
            var classType = Type.GetType(investigatedClass);

            output.AppendLine(GetMistakenPublicFields(classType));
            output.AppendLine(GetMistakenNonPublicMethods(classType));
            output.AppendLine(GetMistakenPublicMethods(classType));

            return output.ToString().TrimEnd();
        }
        private static string GetMistakenNonPublicMethods(Type classType)
        {
            var output = new StringBuilder();

            var nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                output.AppendLine($"{method.Name} have be public!");
            }

            return output.ToString().TrimEnd();
        }
        private static string GetMistakenPublicMethods(Type classType)
        {
            var output = new StringBuilder();

            var publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                output.AppendLine($"{method.Name} have be private!");
            }

            return output.ToString().TrimEnd();

        }
        private static string GetMistakenPublicFields(Type classType)
        {
            var output = new StringBuilder();

            var publicFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            foreach (var field in publicFields)
            {
                output.AppendLine($"{field.Name} must be private!");
            }

            return output.ToString().TrimEnd();
        }
    }
}
