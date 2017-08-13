namespace FerrariProblem
{
    using System;

    public class Ferrari : ICar
    {
        public const string Model = "488-Spider";

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver { get; }

        public string Move()
        {
            return "Zadu6avam sA!";
        }

        public string Stop()
        {
            return "Brakes!";
        }

        // 488-Spider/Brakes!/Zadu6avam sA!/Bat Giorgi

        public override string ToString()
        {
            string ferrari = $"{Model}/{this.Stop()}/{this.Move()}/{this.Driver}";
            return ferrari;
        }
    }
}

