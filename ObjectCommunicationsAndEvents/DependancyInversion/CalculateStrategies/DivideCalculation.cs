namespace DependancyInversion.CalculateStrategies
{
    using Interfaces;
    using System;

    public class DivideCalculation : ICalculate
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            var result = firstOperand / secondOperand;
            return result;
        }
    }
}
