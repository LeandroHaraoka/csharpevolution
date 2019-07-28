using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.Tests02.Interfaces
{
    public interface IIpuntNumbers
    {
        ValueTuple<double, double> GetNumbers();

        double GetNumber();
    }
}
