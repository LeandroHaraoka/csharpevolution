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
            Console.WriteLine("Welcome to C# Evolution Calculator!\n");

            var menu = new Menu();

            var feature = null as IFeature;

            while (feature is null || feature.GetType() != typeof(Exit))
            {
                menu.Show();
                feature = menu.SelectFeature();
               
                if(feature.GetType() != typeof(Exit))
                    ((ICalculatorFeature)feature).Show();
                
                feature.Execute();
            }
        }
    }
}
