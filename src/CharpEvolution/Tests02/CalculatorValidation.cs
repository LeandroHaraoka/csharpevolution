using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.Tests02
{
    public class CalculatorValidation : ICalculatorValidation
    {
        public double SetNumber(string outputText)
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
