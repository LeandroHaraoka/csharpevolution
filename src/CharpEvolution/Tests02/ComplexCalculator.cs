using System;
using System.Diagnostics;
using System.Drawing;
using CsharpEvolution.Tests02.Interfaces;

namespace CsharpEvolution.Tests02
{
    public class ComplexCalculator
    {
        private readonly IShapesAreaCalculation _shapesAreaCalculation;
        private readonly IBasicCalculations _basicCalculations;

        public ComplexCalculator(IShapesAreaCalculation shapesAreaCalculation,
                                 IBasicCalculations basicCalculations)
        {
            _shapesAreaCalculation = shapesAreaCalculation;
            _basicCalculations = basicCalculations;
        }
        public void ComplexCalculatorOperations()
        {
            while (true)
            {
                Console.Write("Please enter an operand (+, -, /, *)" +
                              "\nOr for Square Root (SR)" +
                              "\nOr Cubic Root (CR):" +
                              "\nOr Power of number (PN)" +
                              "\nOr Rest (R)" +
                              "\nOr Square Area (SA)" +
                              "\nOr Triangle Area (TA)" +
                              "\nOr Circle Area (CA)" +
                              "\nOr Rectangle Area (RA):\n\n");
                var operand = Console.ReadLine();

                switch (operand.ToUpper())
                {
                    case "-":
                        _basicCalculations.Subtraction();
                        break;
                    case "+":
                        _basicCalculations.Addition();
                        break;
                    case "/":
                        _basicCalculations.Division();
                        break;
                    case "*":
                        _basicCalculations.Multiplication();
                        break;
                    case "R":
                        _basicCalculations.Rest();
                        break;
                    case "SR":
                        _basicCalculations.SquareRoot();
                        break;
                    case "CR":
                        _basicCalculations.CubicRoot();
                        break;
                    case "PN":
                        _basicCalculations.PowerOfNumber();
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
                        Console.WriteLine("\nInvalid input.");
                        break;
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
