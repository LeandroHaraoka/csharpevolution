﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Calculus
{
    public class Division
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }

        public static double Calculate(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}