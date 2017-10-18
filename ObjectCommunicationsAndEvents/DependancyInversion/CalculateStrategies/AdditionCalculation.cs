namespace DependancyInversion.CalculateStrategies
{
    using DependancyInversion.Interfaces;

    public class AdditionCalculation : ICalculate
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            var result = firstOperand + secondOperand;
            return result;
        }
    }
}
