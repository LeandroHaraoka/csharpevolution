using System;
using System.Collections.Generic;
using System.Text;
using CsharpEvolution.Tests02.Interfaces;

namespace CsharpEvolution.Tests02
{
    public class InputNumbers : IIpuntNumbers
    {
        private readonly ICalculatorValidation _calculatorValidation;

        public InputNumbers(ICalculatorValidation calculatorValidation)
        {
            _calculatorValidation = calculatorValidation;
        }

        public ValueTuple<double, double> GetNumbers()
        {
            const string inputFirstNumber = "Please enter the first number: ";
            const string inputSecondNumber = "Please enter the second number: ";

            var firstNumber = _calculatorValidation.SetNumber(inputFirstNumber);
            var secondNumber = _calculatorValidation.SetNumber(inputSecondNumber);

            var inputNumbers = (firstNumber, secondNumber);

            return inputNumbers;
        }

        public double GetNumber()
        {
            const string input = "Please enter a number: ";

            var inputNumber = _calculatorValidation.SetNumber(input);

            return inputNumber;
        }
    }
}
