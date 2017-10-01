using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [Serializable]
    public class Program
    {
        public static void Main(string[] args)
        {

            var catType = typeof(Cat);

            var method = catType.GetMethod("Hello");

            var types = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .Where(t => t.GetCustomAttribute<AuthorAttribute>() != null);

            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
            }
            
                
            //var parameters = method.GetParameters();
            //foreach (var param in parameters)
            //{
            //    Console.WriteLine(param);
            //}

            //var cat = new Cat("Vankata");
            //method.Invoke(cat, new object[] { 1 });


            //var publicConstructors = catType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            //var constructor = catType.GetConstructor(new[] { typeof(string) });
            //var cat = constructor.Invoke(new[] { "Ivan" });

            //foreach (var constructor in publicConstructors)
            //{
            //    foreach (var param in constructor.GetParameters())
            //    {
            //        Console.WriteLine(param.Name);
            //    }

            //    Console.WriteLine("----------------");
            //}

            //var cat = (Cat)Activator.CreateInstance(typeof(Cat));
            //var cat = Activator.CreateInstance<Cat>();

            //var field = catType.GetField("somePrivateField", BindingFlags.Instance | BindingFlags.NonPublic);
            //Console.WriteLine(field.IsPrivate);
            //Console.WriteLine(field);

            //var cat = new Cat()
            //{
            //    Name = "gosho",
            //    Age = 5
            //};

            //var nameProperty = catType.GetProperty("Name");
            //Console.WriteLine(nameProperty.GetValue(cat));

            //nameProperty.SetValue(cat, "ivan");
            //Console.WriteLine(nameProperty.GetValue(cat));


            //var fields = catType.GetFields(
            //    BindingFlags.Instance | 
            //    BindingFlags.NonPublic);

            //var cat = new Cat();

            //foreach (var field in fields)
            //{
            //    Console.WriteLine(field.Name);
            //    Console.WriteLine(field.FieldType.Name);

            //    if (field.Name.Contains("Name"))
            //    {
            //        field.SetValue(cat, "Pesho"); 
            //    }
            //}

            //Console.WriteLine(cat.Name);
        }
    }
}
