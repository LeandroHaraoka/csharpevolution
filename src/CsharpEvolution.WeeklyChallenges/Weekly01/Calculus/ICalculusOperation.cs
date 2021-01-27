using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Calculus
{
    public interface ICalculusOperation
    {
        double FirstNumber { get; set; }
        double SecondNumber { get; set; }

        double Calculate();
    }
}
