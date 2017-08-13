namespace FerrariProblem
{
    class FerrariExecution
    {
        static void Main()
        {
            var driver = System.Console.ReadLine();

            var ferrari = new Ferrari(driver);

            System.Console.WriteLine(ferrari);

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new System.Exception("No interface ICar was created");
            }

        }
    }
}
