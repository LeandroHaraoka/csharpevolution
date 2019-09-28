using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Home
{
    public static class Menu
    {
        static readonly List<string> features;

        static Menu()
        {
            features = new List<string> { "Calculus", "Memory", "Special Numbers", "Help"};
        }

        public static void ShowMenu()
        {
            features.ForEach((feature) =>
                Console.WriteLine(feature));
        }
    }
}
