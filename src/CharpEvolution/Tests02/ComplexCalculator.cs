using System;
using System.Drawing;

namespace CsharpEvolution.Tests02
{
    public class ComplexCalculator
    {
        private readonly IShapesAreaCalculation _shapesAreaCalculation;

        public ComplexCalculator(IShapesAreaCalculation shapesAreaCalculation)
        {
            _shapesAreaCalculation = shapesAreaCalculation;
        }
        public void ComplexCalculatorOperations()
        {
            double firstNumber = 0;
            double secondNumber = 0;
            double answer = 0;
            double complexNumber = 0;

            while (true)
            {
                Console.Write("Please enter an operand (+, -, /, *)" +
                              "\nOr for Square Root (SR)" +
                              "\nOr Cubic Root (CR):" +
                              "\nOr Power of number (PN)" +
                              "\nOr Square Area (SA)" +
                              "\nOr Triangle Area (TA)" +
                              "\nOr Circle Area (CA)" +
                              "\nOr Rectangle Area (RA):\n");
                var operand = Console.ReadLine();

                switch (operand)
                {
                    case "-":
                        answer = firstNumber - secondNumber;
                        break;
                    case "+":
                        answer = firstNumber + secondNumber;
                        break;
                    case "/":
                        answer = firstNumber / secondNumber;
                        break;
                    case "*":
                        answer = firstNumber * secondNumber;
                        break;
                    case "SR":
                        answer = Math.Sqrt(complexNumber);
                        break;
                    case "CR":
                        answer = Math.Ceiling(Math.Pow(complexNumber, (double)1 / 3));
                        break;
                    case "PN":
                        answer = Math.Pow(firstNumber, secondNumber);
                        break;
                    case "SA":
                        _shapesAreaCalculation.GetSquareArea();
                        break;
                    case "TA":
                        _shapesAreaCalculation.GetTriangleArea();
                        break;
                    case "CA":
                        _shapesAreaCalculation.GetCircleArea();
                        break;
                    case "RA":
                        _shapesAreaCalculation.GetRectangleArea();
                        break;
                    default:
                        answer = 0;
                        break;
                }

                if (answer != 0)
                {
                    Console.WriteLine(firstNumber + " " + operand + " " + secondNumber + " = " + answer);
                }

                Console.WriteLine("\n\nDo you want to break? (Y/N)");
                ConsoleKeyInfo status = Console.ReadKey();

                if (status.Key == ConsoleKey.Y)
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}
