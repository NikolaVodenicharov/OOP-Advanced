namespace CreateAttributes
{
    using System;
    using System.Linq;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var startUp = typeof(StartUp);
            var methods = startUp.GetMethods();

            foreach (var methodInfo in methods)
            {
                if (methodInfo.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = methodInfo.GetCustomAttributes(false);
                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{methodInfo.Name} is wrriten by {attribute.Name}");
                    }
                }
            }
        }
    }
}
