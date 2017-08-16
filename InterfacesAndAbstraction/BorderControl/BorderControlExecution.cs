namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class BorderControlExecution
    {
        static void Main(string[] args)
        {
            var inhabitants = new List<IBirthdate>();

            while (true)
            {
                var input = Console.ReadLine();

                bool stopLoop = input.Equals("End", StringComparison.InvariantCultureIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                AddInhiabitant(inhabitants, input);
            }

            var searchedYear = Console.ReadLine();

            foreach (var inhabitant in inhabitants)
            {
                var birthYear = inhabitant.DateOfBirth.Split('/').Last();

                if (birthYear == searchedYear)
                {
                    Console.WriteLine(inhabitant.DateOfBirth);
                }
            }
        }

        private static void AddInhiabitant(List<IBirthdate> inhabitats, string input)
        {
            var splitInput = input.Split();

            //var isRobot = splitInput[0].Equals("Robot", StringComparison.OrdinalIgnoreCase);
            var isCitizen = splitInput[0].Equals("Citizen", StringComparison.OrdinalIgnoreCase);
            var isPet = splitInput[0].Equals("Pet", StringComparison.OrdinalIgnoreCase);

            //if (isRobot)
            //{
            //    var inputRobot = new Robot(splitInput[1], splitInput[2]);
            //}

            if (isCitizen)
            {
                var inputCitizen = new Citizen(splitInput[1], splitInput[2], splitInput[3], splitInput[4]);
                inhabitats.Add(inputCitizen);
            }
            else if (isPet)
            {
                var inputPet = new Pet(splitInput[1], splitInput[2]);
                inhabitats.Add(inputPet);
            }
            else
            {
                // undefined
            }
        }
    }
}
