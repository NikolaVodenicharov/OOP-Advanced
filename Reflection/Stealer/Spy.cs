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
            var classType = Type.GetType(investigatedClass);
            var classFields = classType.GetFields(
                BindingFlags.Instance | 
                BindingFlags.Public | 
                BindingFlags.NonPublic | 
                BindingFlags.Static);

            var output = new StringBuilder();
            output.AppendLine($"Class under investigation: {investigatedClass}");

            var classInstance = Activator.CreateInstance(classType);

            foreach (var field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                output.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
