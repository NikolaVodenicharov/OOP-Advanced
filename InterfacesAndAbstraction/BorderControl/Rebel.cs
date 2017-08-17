using System;

namespace BorderControl
{
    public class Rebel : IHuman, IBuyer
    {
        public string group;

        public Rebel(string name, string age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.group = group;
            this.Food = 0;
        }

        public string Name { get; }

        public string Age { get; }

        public double Food { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
