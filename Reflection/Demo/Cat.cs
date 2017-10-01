using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [Author(Name = "Jon")]
    public class Cat : Animal
    {
        public static string someStaticPublicField;
        private static string someStaticPrivateField;
        public string somePublicField;
        private string somePrivateField;

        public Cat()
        {
            this.Name = "unknow";
        }

        public Cat(string name)
        {
            this.Name = name;
        }

        public Cat (string name, int age)
            : this(name)
        {
            this.Age = age;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public void Hello(int num)
        {
            Console.WriteLine($"Hello from {this.Name} {num}");
        }
    }
}
