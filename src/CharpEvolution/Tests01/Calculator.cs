using System;

namespace CsharpEvolution.Tests01
{
    public class Calculator
    {
        public static void SimpleCalculator()
        {
            while (true)
            {
                var firstNumber = SetNumber("Please enter the first number: ");
                var secondNumber = SetNumber("Please enter the second number: ");
                Console.Write("Please enter an operand (+, -, /, *): ");
                var operand = Console.ReadLine();
                double answer;

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
                    default:
                        answer = 0;
                        break;
                }

                Console.WriteLine(firstNumber + " " + operand + " " + secondNumber + " = " + answer);
                Console.WriteLine("\n\nDo you want to break (Y/N)?");
                ConsoleKeyInfo status = Console.ReadKey();

                if (status.Key == ConsoleKey.Y)
                {
                    break;
                }
                Console.Clear();
            }
        }

        private static double SetNumber(string outputText)
        {
            double parse;
            Console.Write(outputText);
            string inputText = Console.ReadLine();
            while (!double.TryParse(inputText, out parse))
            {
                Console.WriteLine("Incorrect input!\nIt should be a number.\n");
                Console.Write(outputText);
                inputText = Console.ReadLine();
            }
            return double.Parse(inputText);
        }
    }
}
