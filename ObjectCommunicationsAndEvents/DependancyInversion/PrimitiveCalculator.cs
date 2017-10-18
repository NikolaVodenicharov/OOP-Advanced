namespace DependancyInversion
{
    using Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PrimitiveCalculator
    {
        private ICalculate currentCalculateCommand;
        private IDictionary<char, ICalculate> calculateCommands;

        public PrimitiveCalculator(ICalculate initialCalculateCommand, IDictionary<char, ICalculate> calculateCommands)
        {
            this.currentCalculateCommand = initialCalculateCommand;
            this.calculateCommands = calculateCommands;
        }

        public void changeStrategy(char action)
        {
            this.currentCalculateCommand = this.calculateCommands[action];
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            var result = this.currentCalculateCommand.Calculate(firstOperand, secondOperand);
            return result;
        }
    }
}
