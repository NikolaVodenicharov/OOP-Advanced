namespace DependancyInversion
{
    using CalculateStrategies;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class DependancyInversionExecution
    {
        public static void Main()
        {
            var initialCalculateCommand = new AdditionCalculation();
            var calculateCommands = new Dictionary<char, ICalculate>()
            {
                {'+', new AdditionCalculation() },
                {'-', new SubstractionCalculation() },
                {'*', new MultiplyCalculation() },
                {'/', new DivideCalculation() }
            };
            var primitiveCalculator = new PrimitiveCalculator(initialCalculateCommand, calculateCommands);


            while (true)
            {
                var line = Console.ReadLine().Split();

                var isLoopBreak = line[0].Equals("End");
                if (isLoopBreak)
                {
                    break;
                }

                if (line[0].Equals("mode"))
                {
                    var action = char.Parse(line[1]);
                    primitiveCalculator.changeStrategy(action);
                }
                else
                {
                    int result = Calculate(primitiveCalculator, line);
                    Console.WriteLine(result);
                }
            }
        }

        private static int Calculate(PrimitiveCalculator primitiveCalculator, string[] line)
        {
            var firstOperand = int.Parse(line[0]);
            var secondOperand = int.Parse(line[1]);
            var result = primitiveCalculator.performCalculation(firstOperand, secondOperand);
            return result;
        }
    }
}
