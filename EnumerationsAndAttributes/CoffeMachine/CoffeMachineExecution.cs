
    using System;

    public class CoffeMachineExecution
    {
        public static void Main()
        {
            CoffeeMachine machine = new CoffeeMachine();

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 1)
                {
                    machine.InsertCoin(input[0]);
                }
                else
                {
                    var size = input[0];
                    var type = input[1];
                    machine.BuyCoffee(size, type);
                }
            }

            foreach (var coffeeType in machine.CoffeesSold)
            {
                Console.WriteLine(coffeeType);
            }

        }
    }

