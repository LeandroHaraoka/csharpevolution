using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.WeeklyChallenges.Weekly01.Home
{
    public class Exit : IFeature
    {
        public void Execute() 
        {
            Environment.Exit(0);
        }
    }
}
