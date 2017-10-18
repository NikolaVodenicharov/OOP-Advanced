namespace DependancyInversion.CalculateStrategies
{
    using Interfaces;
    using System;

    public class MultiplyCalculation : ICalculate
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            var result = firstOperand * secondOperand;
            return result;
        }
    }
}
