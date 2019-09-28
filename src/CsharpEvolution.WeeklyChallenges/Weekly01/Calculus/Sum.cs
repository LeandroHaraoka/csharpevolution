using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Calculus
{
    public class Sum : IMathOperation
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }

        public static double Calculate(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
