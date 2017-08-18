namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class BorderControlExecution
    {
        static void Main(string[] args)
        {
            var humans = new Dictionary<string, IBuyer>();
            int inputHumanNumber = ReadInputHumanNumber();
            ReadFromConsoleAddToHumans(humans, inputHumanNumber);
            ReadFromConsolePurhaseFood(humans);

            var purchasedFood = humans.Sum(x => x.Value.Food);
            Console.WriteLine(purchasedFood);
        }

        private static void ReadFromConsolePurhaseFood(Dictionary<string, IBuyer> humans)
        {
            while (true)
            {
                var input = Console.ReadLine();

                bool stopLoop = input.Equals("End", StringComparison.InvariantCultureIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                if (humans.ContainsKey(input))
                {
                    humans[input].BuyFood();
                }
            }
        }

        private static void ReadFromConsoleAddToHumans(Dictionary<string, IBuyer> humans, int inputHumanNumber)
        {
            for (int i = 0; i < inputHumanNumber; i++)
            {
                var input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    var citizen = new Citizen(input[0], input[1], input[2], input[3]);
                    humans[input[0]] = citizen;
                }
                else if (input.Length == 3)
                {
                    var rebel = new Rebel(input[0], input[1], input[2]);
                    humans[input[0]] = rebel;
                }
                else
                {
                    // Invalid input, just skip it.
                }
            }
        }

        private static int ReadInputHumanNumber()
        {
            var inputHumanNumber = 0;

            var input = Console.ReadLine();
            int.TryParse(input, out inputHumanNumber);

            return inputHumanNumber;
        }
    }
}
