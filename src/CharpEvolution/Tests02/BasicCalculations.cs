using System;
using CsharpEvolution.Tests02.Interfaces;

namespace CsharpEvolution.Tests02
{
    public class BasicCalculations : IBasicCalculations
    {

        private readonly IIpuntNumbers _inputNumbers;

        public BasicCalculations(IIpuntNumbers inputNumbers)
        {
            _inputNumbers = inputNumbers;
        }

        public void Addition()
        {
            var numbers = _inputNumbers.GetNumbers();
            var result = numbers.Item1 + numbers.Item2;

            Console.WriteLine(numbers.Item1 + " + " + numbers.Item2 + " = " + result);
        }

        public void Division()
        {
            var numbers = _inputNumbers.GetNumbers();
            var result = numbers.Item1 / numbers.Item2;

            Console.WriteLine(numbers.Item1 + " ÷ " + numbers.Item2 + " = " + result);
        }

        public void Multiplication()
        {
            var numbers = _inputNumbers.GetNumbers();
            var result = numbers.Item1 * numbers.Item2;

            Console.WriteLine(numbers.Item1 + " * " + numbers.Item2 + " = " + result);
        }

        public void Subtraction()
        {
            var numbers = _inputNumbers.GetNumbers();
            var result = numbers.Item1 - numbers.Item2;

            Console.WriteLine(numbers.Item1 + " - " + numbers.Item2 + " = " + result);
        }

        public void Rest()
        {
            var numbers = _inputNumbers.GetNumbers();
            var result = numbers.Item1 % numbers.Item2;

            Console.WriteLine("The rest of the operation is: " + result);
        }

        public void SquareRoot()
        {
            var inputNumber = _inputNumbers.GetNumber();
            var result = Math.Sqrt(inputNumber);

            Console.WriteLine("The square root of " + inputNumber + " is: " + result);
        }

        public void CubicRoot()
        {
            var inputNumber = _inputNumbers.GetNumber();
            var result = Math.Ceiling(Math.Pow(inputNumber, (double)1 / 3));

            Console.WriteLine("The cubic root of " + inputNumber + " is: " + result);
        }

        public void PowerOfNumber()
        {
            var numbers = _inputNumbers.GetNumbers();
            var result = Math.Pow(numbers.Item1, numbers.Item2);


            Console.WriteLine("The power of the numbers of the operation is: " + result);
        }
    }
}
