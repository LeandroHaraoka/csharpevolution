using CsharpEvolution.WeeklyChallenges.Weekly01.Calculus;
using CsharpEvolution.WeeklyChallenges.Weekly01.Home;
using System;
using System.Linq;

namespace CsharpEvolition.WeeklyChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C# Evolution Calculator!");

            var feature = new Calculus();
            feature.Execute();
        }
    }
}
