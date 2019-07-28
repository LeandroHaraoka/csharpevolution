using System;
using CsharpEvolution.Tests01;
using CsharpEvolution.Tests02;
using CsharpEvolution.Tests02.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CharpEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IBasicCalculations, BasicCalculations>()
                .AddSingleton<ICalculatorValidation, CalculatorValidation>()
                .AddSingleton<IIpuntNumbers, InputNumbers>()
                .AddSingleton<IShapesAreaCalculation, ShapesAreaCalculation>()
                .AddSingleton<ComplexCalculator>()
                .BuildServiceProvider();

            var teste = serviceProvider.GetService<ComplexCalculator>();
            teste.ComplexCalculatorOperations();
        }
    }
}
