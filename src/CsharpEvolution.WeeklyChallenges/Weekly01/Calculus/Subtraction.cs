using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Calculus
{
    public class Subtraction : ICalculusOperation
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }

        public double Calculate()
        {
            return FirstNumber - SecondNumber;
        }
    }
}
