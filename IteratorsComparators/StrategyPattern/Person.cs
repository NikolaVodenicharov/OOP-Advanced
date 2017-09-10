﻿namespace StrategyPattern
{
    public class Person
    {
        public Person (string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            string output = $"{this.Name} {this.Age}";
            return output;
        }
    }
}
